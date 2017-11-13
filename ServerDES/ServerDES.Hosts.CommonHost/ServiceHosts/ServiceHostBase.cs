using System.ServiceModel;

namespace ServerDES.Hosts.CommonHost.ServiceHosts
{
    /*
     * Base class for other ServiceHost classes.
     */
    public class ServiceHostBase
    {
        protected BasicHttpBinding BasicBinding;

        public ServiceHostBase()
        {
            BasicBinding = new BasicHttpBinding();
            BasicBinding.Name = "DefaultBasicBinding";
            BasicBinding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            BasicBinding.Security.Mode = BasicHttpSecurityMode.None;
        }
    }
}
