using SignalRDES.Core.Managers;
using SignalRDES.Data.Managers;
using Unity;

namespace SignalRDES.Installer.Components
{
    /*
     * Data layer registrations in UnityContainer.
     */
    public class DataComponent
    {
        public IUnityContainer Register(IUnityContainer container)
        {
            container.RegisterType<IMailSimulatorFileManager, MailSimulatorFileManager>();

            return container;
        }
    }
}
