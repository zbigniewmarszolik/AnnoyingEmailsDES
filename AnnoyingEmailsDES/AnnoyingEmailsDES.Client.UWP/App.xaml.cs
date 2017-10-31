using AnnoyingEmailsDES.Client.Domain.ViewModels;
using AnnoyingEmailsDES.Client.Installer.Registries;
using AnnoyingEmailsDES.Client.UWP.Registries;
using AnnoyingEmailsDES.Client.UWP.Views;
using StructureMap;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AnnoyingEmailsDES.Client.UWP
{
    sealed partial class App : Application
    {
        private IContainer _container { get; set; }

        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;

            ConfigureContainer();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    var simulationViewModel = _container.GetInstance<ISimulationVM>();
                    rootFrame.Navigate(typeof(SimulationView), simulationViewModel);
                }
                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            deferral.Complete();
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }
        }

        private void ConfigureContainer()
        {
            var registry = new Registry();
            registry.IncludeRegistry<PresentationRegistry>();
            registry.IncludeRegistry<InfrastructureRegistry>();
            registry.IncludeRegistry<ServicesRegistry>();
            registry.IncludeRegistry<SimulatorRegistry>();

            _container = new Container(registry);
        }
    }
}
