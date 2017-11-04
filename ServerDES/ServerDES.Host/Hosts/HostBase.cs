using System;
using System.ServiceModel;

namespace ServerDES.Host.Hosts
{
    /*
     * Base class for other Host classes.
     */
    public abstract class HostBase
    {
        protected Uri BaseAddress { get; set; }
        protected BasicHttpBinding BasicBinding { get; set; }

        public HostBase()
        {
            BaseAddress = new Uri("http://localhost:8000/");

            BasicBinding = new BasicHttpBinding();
            BasicBinding.Name = "DefaultBinding";
            BasicBinding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            BasicBinding.Security.Mode = BasicHttpSecurityMode.None;
        }
    }
}
