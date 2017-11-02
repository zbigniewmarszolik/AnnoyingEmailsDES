using System.Collections.Generic;
using AnnoyingEmailsDES.Client.Services.Contracts;
using System.ServiceModel;
using AnnoyingEmailsDES.Client.Domain.DTOs;

namespace AnnoyingEmailsDES.Client.Services.Proxies
{
    /*
     * Remote WCF service proxy client class.
     */
    public class MailSimulationProxy : ClientBase<IMailSimulationService>, IMailSimulationService
    {
        public MailSimulationProxy(BasicHttpBinding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {}

        public IList<FriendDTO> ProvideTopologyInput()
        {
            return base.Channel.ProvideTopologyInput();
        }

        public MailDTO ProvideScenarioInput()
        {
            return base.Channel.ProvideScenarioInput();
        }
    }
}
