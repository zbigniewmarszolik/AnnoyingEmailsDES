using SignalRDES.Core.Services;
using SignalRDES.Service.Services;
using Unity;

namespace SignalRDES.Installer.Components
{
    public class ServiceComponent
    {
        public IUnityContainer Register(IUnityContainer container)
        {
            container.RegisterType<IMailSimulatorService, MailSimulatorService>();

            return container;
        }
    }
}
