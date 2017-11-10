using System.ServiceModel;

namespace AnnoyingEmailsDES.Client.Services.Services
{
    /*
     * Base class for WCF services defining the binding and remote address.
     */
    public abstract class ServiceBase
    {
        protected BasicHttpBinding Binding { get; set; }

        public ServiceBase()
        {
            Binding = new BasicHttpBinding();
        }
    }
}
