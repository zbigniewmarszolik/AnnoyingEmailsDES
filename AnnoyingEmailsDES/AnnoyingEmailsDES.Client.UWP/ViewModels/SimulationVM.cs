using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AnnoyingEmailsDES.Client.Domain.Repositories;
using AnnoyingEmailsDES.Client.Domain.Services;
using AnnoyingEmailsDES.Client.Domain.Simulators;
using AnnoyingEmailsDES.Client.Domain.ViewModels;
using AnnoyingEmailsDES.Client.UWP.Helpers;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace AnnoyingEmailsDES.Client.UWP.ViewModels
{
    /*
     * ViewModel for SimulationView. Extends BindableBase (Prism.MVVM framework) and implements ISimulationVM abstraction.
     * This class is responsible for processing user interface requests and calling logic of the application depending on the app's state.
     */
    public class SimulationVM : BindableBase, ISimulationVM
    {
        private IContainer _container { get; set; }

        public Action DbErrorAction { get; set; }
        public Action ConnectionErrorAction { get; set; }
        public Action<IHistoryVM> HistoryAction { get; set; }

        private readonly ISimulationsRepository _simulationsRepository;
        private readonly IMailSimulator _mailSimulator;
        private readonly ISimulationInputService _simulationInputService;
        private readonly IMailsMapping _mailsMapping;
        private readonly FriendsHelper _friendsHelper;
        private readonly MailsHelper _mailsHelper;

        private IList<Friend> _friendsGroup { get; set; }
        private IList<Friend> _receivers { get; set; }
        private IList<Mail> _mailEvents { get; set; }
        private Mail _firstMail { get; set; }
        private DispatcherTimer _discreteEventTimer { get; set; }

        private ICommand _showHistoryCommand;
        public ICommand ShowHistoryCommand => _showHistoryCommand ?? (_showHistoryCommand = new DelegateCommand(() => OnHistoryClicked()));

        private ICommand _downloadDataCommand;
        public ICommand DownloadDataCommand => _downloadDataCommand ?? (_downloadDataCommand = new DelegateCommand(() => OnDownloadClicked()));

        private ICommand _startCommand;
        public ICommand StartCommand => _startCommand ?? (_startCommand = new DelegateCommand(() => OnStartClicked()));

        private ICommand _abortCommand;
        public ICommand AbortCommand => _abortCommand ?? (_abortCommand = new DelegateCommand(() => OnAbortClicked()));

        private ObservableCollection<Mail> _observableMailEvents;
        public ObservableCollection<Mail> ObservableMailEvents
        {
            get => _observableMailEvents;
            set { _observableMailEvents = value; OnPropertyChanged(() => ObservableMailEvents); }
        }

        private bool _isHistoryEnabled;
        public bool IsHistoryEnabled
        {
            get => _isHistoryEnabled;
            set { _isHistoryEnabled = value; OnPropertyChanged(() => IsHistoryEnabled); }
        }

        private bool _isDownloadEnabled;
        public bool IsDownloadEnabled
        {
            get => _isDownloadEnabled;
            set { _isDownloadEnabled = value; OnPropertyChanged(() => IsDownloadEnabled); }
        }

        private bool _isStartEnabled;
        public bool IsStartEnabled
        {
            get => _isStartEnabled;
            set { _isStartEnabled = value; OnPropertyChanged(() => IsStartEnabled); }
        }

        private bool _isAbortEnabled;
        public bool IsAbortEnabled
        {
            get => _isAbortEnabled;
            set { _isAbortEnabled = value; OnPropertyChanged(() => IsAbortEnabled); }
        }

        private bool _isEventRunning;
        public bool IsEventRunning
        {
            get => _isEventRunning;
            set { _isEventRunning = value; OnPropertyChanged(() => IsEventRunning); }
        }

        //Constructor - injecting abstractions with StructureMap, initializing collections and setting the timer's interval,
        //then finally calling the method which initializes buttons and progress ring's availability
        public SimulationVM
            (IContainer container,
            ISimulationsRepository simulationsRepository,
            IMailSimulator mailSimulator,
            IMailsMapping mailsMapping,
            ISimulationInputService simulationInputService,
            FriendsHelper friendsHelper,
            MailsHelper mailsHelper)
        {
            _container = container;
            _simulationsRepository = simulationsRepository;
            _mailSimulator = mailSimulator;
            _mailsMapping = mailsMapping;
            _simulationInputService = simulationInputService;
            _friendsHelper = friendsHelper;
            _mailsHelper = mailsHelper;

            _simulationsRepository.DatabaseErrorAction = DbError;
            _simulationInputService.ServerErrorAction = SrvError;
            _simulationInputService.TopologyResponseSignalR = OnTopologyReceived;
            _simulationInputService.ScenarioResponseSignalR = OnScenarioReceived;

            _receivers = new List<Friend>();
            _mailEvents = new List<Mail>();
            _observableMailEvents = new ObservableCollection<Mail>();

            _discreteEventTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2.0)
            };

            InitEnableValues();
        }

        //Initiating values corresponding to the availability of buttons and progress ring.
        private void InitEnableValues()
        {
            IsHistoryEnabled = true;
            IsDownloadEnabled = true;
            IsStartEnabled = false;
            IsAbortEnabled = false;
            IsEventRunning = false;
        }

        //Printing the simulation history.
        private void OnHistoryClicked()
        {
            var historyViewModel = _container.GetInstance<IHistoryVM>();
            HistoryAction(historyViewModel);
        }

        //Connecting to the server to obtain topology and scenario inputs for the simulation (2 versions below):

        // -> SignalR version:
        /*
        private void OnDownloadClicked()
        {
            IsHistoryEnabled = false;
            IsDownloadEnabled = false;
            IsEventRunning = true;

            try
            {
                _simulationInputService.QueryTopology();
            }
            catch (Exception e)
            {
                InitEnableValues();
                SrvError();
            }
        }
        */

        // -> WCF version:

        private async void OnDownloadClicked()
        {
            IsHistoryEnabled = false;
            IsDownloadEnabled = false;
            IsEventRunning = true;

            try
            {
                _friendsGroup = await _simulationInputService.GetAllGroupMembers();
                _firstMail = await _simulationInputService.GetStartingScenario();
            }
            catch (Exception e)
            {
                InitEnableValues();
                return;
            }

            for (var i = 0; i < _friendsGroup.Count; i++)
            {
                _friendsGroup[i] = _friendsHelper.AssignFriendProperties(_friendsGroup[i]);
            }

            IsHistoryEnabled = true;
            IsEventRunning = false;
            IsStartEnabled = true;
        }

        //Start click - set the timer's event and start it. Also clearing view from previous simulation.
        private void OnStartClicked()
        {
            ObservableMailEvents.Clear();

            IsHistoryEnabled = false;
            IsStartEnabled = false;
            IsAbortEnabled = true;
            IsEventRunning = true;

            _discreteEventTimer.Tick += DiscreteEventOccurence;
            _discreteEventTimer.Start();
        }

        //Stop click - call stopping method.
        private void OnAbortClicked()
        {
            StopSimulation();
        }

        //Stopping the timer, saving results to local SQLite database and clearing current data.
        private void StopSimulation()
        {
            _discreteEventTimer.Tick -= DiscreteEventOccurence;
            _discreteEventTimer.Stop();

            IsEventRunning = false;
            IsDownloadEnabled = true;
            IsAbortEnabled = false;
            IsHistoryEnabled = true;

            var sim = new SimulationEntity()
            {
                SimulationDate = DateTime.Now,
                Mails = new List<MailEntity>()
            };

            foreach (var item in _mailEvents)
            {
                var mailEntity = _mailsMapping.ModelToEntity(item);

                sim.Mails.Add(mailEntity);
            }

            _simulationsRepository.CreateSimulation(sim);

            _mailEvents.Clear();
        }

        //Event for processing the simulation that is called on each timer's click.
        private void DiscreteEventOccurence(object sender, object e)
        {
            if (_friendsGroup.All(x => x.IsFirstPostOnWall == false)) // if the event is our input scenario (first occurence)
            {
                var firstReceiver = _friendsGroup.First(x => x.Id == _firstMail.ReceiverId); // find receiver
                firstReceiver.Author = _firstMail.SenderId;
                firstReceiver = _mailSimulator.ModifyReceiver(firstReceiver, _friendsGroup.Count); // modify the receiver

                _firstMail.ReceiverValue = _mailsHelper.SetReceiverValue(_firstMail.ReceiverId);
                ObservableMailEvents.Add(_firstMail); // view and data update
                _mailEvents.Add(_firstMail);

                _receivers.Add(firstReceiver);
            }

            else
            {
                var newMails = _mailSimulator.SendMessage(_receivers, _mailEvents.Count); // sending message (or messages)

                _receivers.Clear(); // clearing receivers for the next tick

                foreach (var item in newMails) // for each messages sent in this tick, predefine the message's receiver
                {
                    if (item.ReceiverId != 0)
                    {
                        var newReceiver = _friendsGroup.First(x => x.Id == item.ReceiverId);
                        newReceiver.Author = item.SenderId;

                        _receivers.Add(newReceiver);
                    }
                }

                for (var i = 0; i < _receivers.Count; i++) // preparing the current receivers for next wave in the next tick
                {
                    _receivers[i] = _mailSimulator.ModifyReceiver(_receivers[i], _friendsGroup.Count); // exactly doing it here
                }

                foreach (var item in newMails) // view and data update
                {
                    item.ReceiverValue = _mailsHelper.SetReceiverValue(item.ReceiverId);

                    ObservableMailEvents.Add(item);
                    _mailEvents.Add(item);
                }

                if (newMails.All(x => x.ReceiverId == 0)) // stop condition if all are refusing to forward the annoying e-mail
                {
                    StopSimulation();
                }
            }
        }

        //Method responsible for showing the database error box.
        private void DbError()
        {
            DbErrorAction();
        }

        //Method responsible for showing the server connection error box.
        private void SrvError()
        {
            ConnectionErrorAction();
        }

        //Method handling topology response from SignalR server.
        private void OnTopologyReceived(IList<Friend> friends)
        {
            _friendsGroup = new List<Friend>();

            foreach (var item in friends)
            {
                _friendsGroup.Add(item);
            }

            for (var i = 0; i < _friendsGroup.Count; i++)
            {
                _friendsGroup[i] = _friendsHelper.AssignFriendProperties(_friendsGroup[i]);
            }

            _simulationInputService.QueryScenario();
        }

        //Method handling scenario response from SignalR server.
        private async void OnScenarioReceived(Mail mail)
        {
            _firstMail = mail;

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    IsHistoryEnabled = true;
                    IsEventRunning = false;
                    IsStartEnabled = true;
                });
        }
    }
}
