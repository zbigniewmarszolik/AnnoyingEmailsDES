using AnnoyingEmailsDES.Client.Services.Contracts;
using System.ServiceModel;
using AnnoyingEmailsDES.Client.Domain.DTOs;

namespace AnnoyingEmailsDES.Client.Services.Proxies
{
    /*
     * Remote WCF service proxy for scenario.
     */
    public class MailScenarioProxy : ClientBase<IMailScenarioService>, IMailScenarioService
    {
        public MailScenarioProxy(BasicHttpBinding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        { }

        public MailDTO ProvideScenarioInput()
        {
            return base.Channel.ProvideScenarioInput();
        }
    }
}
