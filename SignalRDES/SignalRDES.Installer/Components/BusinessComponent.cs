using SignalRDES.Business.Businesses;
using SignalRDES.Core.Businesses;
using Unity;

namespace SignalRDES.Installer.Components
{
    public class BusinessComponent
    {
        public IUnityContainer Register(IUnityContainer container)
        {
            container.RegisterType<IMailSimulatorBusiness, MailSimulatorBusiness>();

            return container;
        }
    }
}
