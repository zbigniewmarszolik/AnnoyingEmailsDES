using Microsoft.Owin.Cors;
using Owin;
using Unity;
using SignalRDES.Installer.Components;
using Microsoft.AspNet.SignalR;
using SignalRDES.WebHost.Hubs;
using SignalRDES.Core.Services;

namespace SignalRDES.WebHost
{
    /*
     * Startup - configuration of UnityContainer and mapping SignalR hubs.
     */
    public class Startup
    {
        private IUnityContainer _container;

        public void Configuration(IAppBuilder app)
        {
            RegisterComponents();

            var mailSimulatorService = _container.Resolve<IMailSimulatorService>();
            var h = new MailSimulatorHub(mailSimulatorService);

            GlobalHost.DependencyResolver.Register(typeof(MailSimulatorHub), () => h);

            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }

        private void RegisterComponents()
        {
            _container = new UnityContainer();

            var businessComponent = new BusinessComponent();
            var dataComponent = new DataComponent();
            var serviceComponent = new ServiceComponent();

            _container = businessComponent.Register(_container);
            _container = dataComponent.Register(_container);
            _container = serviceComponent.Register(_container);
        }
    }
}
