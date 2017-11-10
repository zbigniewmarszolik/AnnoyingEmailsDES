using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AnnoyingEmailsDES.Client.Domain.Repositories;
using AnnoyingEmailsDES.Client.Domain.ViewModels;
using AnnoyingEmailsDES.Client.UWP.Helpers;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace AnnoyingEmailsDES.Client.UWP.ViewModels
{
    /*
     * HistoryVM for HistoryView. Extends BindableBase (Prism.MVVM framework) and implements IHistoryVM abstraction.
     * This class is responsible for printing the history of all simulations.
     */
    public class HistoryVM : BindableBase, IHistoryVM
    {
        public Action DbErrorAction { get; set; }

        private readonly ISimulationsRepository _simulationsRepository;
        private readonly ISimulationsMapping _simulationsMapping;
        private readonly MailsHelper _mailsHelper;

        public ObservableCollection<Simulation> ObservableSimulations { get; set; }

        //Constructor - injecting abstractions with StructureMap.
        public HistoryVM
            (ISimulationsRepository simulationsRepository, 
            ISimulationsMapping simulationsMapping,
            MailsHelper mailsHelper)
        {
            _simulationsRepository = simulationsRepository;
            _simulationsMapping = simulationsMapping;
            _mailsHelper = mailsHelper;

            _simulationsRepository.DatabaseErrorAction = DbError;

            ObservableSimulations = new ObservableCollection<Simulation>();

            FillView();
        }

        //Method responsible for getting data from SQLite local database and presenting it on view.
        private void FillView()
        {
            var data = _simulationsRepository.ReadSimulations();

            foreach(var item in data)
            {
                var simulation = _simulationsMapping.EntityToModel(item);

                simulation.SimulationDate = simulation.SimulationDate.ToLocalTime();

                foreach(var m in simulation.Mails)
                {
                    m.ReceiverValue = _mailsHelper.SetReceiverValue(m.ReceiverId);
                }

                ObservableSimulations.Add(simulation);
            }
        }

        //Method responsible for showing the database error box.
        private void DbError()
        {
            DbErrorAction();
        }
    }
}
