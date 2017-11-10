using System.ServiceModel;

namespace ServerDES.CommonServiceBus.MicroserviceHosts
{
    /*
     * Base class for other MicroserviceHost classes.
     */
    public abstract class MicroserviceHostBase
    {
        protected BasicHttpBinding BasicBinding;

        public MicroserviceHostBase()
        {
            BasicBinding = new BasicHttpBinding();
            BasicBinding.Name = "DefaultBasicBinding";
            BasicBinding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            BasicBinding.Security.Mode = BasicHttpSecurityMode.None;
        }
    }
}
