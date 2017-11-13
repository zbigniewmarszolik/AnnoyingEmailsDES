using SignalRDES.Core.Services;
using SignalRDES.Service.Services;
using Unity;

namespace SignalRDES.Installer.Components
{
    /*
     * Service layer registrations in UnityContainer.
     */
    public class ServiceComponent
    {
        public IUnityContainer Register(IUnityContainer container)
        {
            container.RegisterType<IMailSimulatorService, MailSimulatorService>();

            return container;
        }
    }
}
