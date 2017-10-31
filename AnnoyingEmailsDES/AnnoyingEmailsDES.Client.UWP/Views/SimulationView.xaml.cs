using AnnoyingEmailsDES.Client.Domain.ViewModels;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AnnoyingEmailsDES.Client.UWP.Views
{
    public sealed partial class SimulationView : Page
    {
        public SimulationView()
        {
            this.InitializeComponent();
        }

        //Getting DataContext (ViewModel) as navigation parameter, assigning actions and making the back button invisible.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ISimulationVM vm = (ISimulationVM)e.Parameter;

            DataContext = vm;

            vm.DbErrorAction = PopDbErrorAsync;

            vm.HistoryAction = x => History(x);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        //Navigating to HistoryView with its ViewModel.
        private void History(IHistoryVM vm)
        {
            Frame.Navigate(typeof(HistoryView), vm);
        }

        //Showing the database error dialog.
        private async void PopDbErrorAsync()
        {
            UICommand okButton = new UICommand("OK");

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () =>
                {
                    var dialog = new MessageDialog("Error connecting to the local database!", "SQLite ERROR");
                    dialog.Commands.Add(okButton);
                    await dialog.ShowAsync();
                });
        }
    }
}
