using AnnoyingEmailsDES.Client.Domain.ViewModels;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AnnoyingEmailsDES.Client.UWP.Views
{
    public sealed partial class HistoryView : Page
    {
        public HistoryView()
        {
            this.InitializeComponent();
        }

        //Getting DataContext (ViewModel) as navigation parameter, assigning actions and making the back button visible.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IHistoryVM vm = (IHistoryVM)e.Parameter;

            DataContext = vm;

            vm.DbErrorAction = PopDbErrorAsync;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        //Showing the database error dialog.
        private async void PopDbErrorAsync()
        {
            UICommand okButton = new UICommand("OK");

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () =>
                {
                    var dialog = new MessageDialog("Could not connect to the local database.", "ERROR");
                    dialog.Commands.Add(okButton);
                    await dialog.ShowAsync();
                });
        }
    }
}
