using AnnoyingEmailsDES.Client.Services.Contracts;
using System.ServiceModel;
using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Services.Proxies
{
    /*
     * Remote WCF service proxy for topology.
     */
    public class MailTopologyProxy : ClientBase<IMailTopologyService>, IMailTopologyService
    {
        public MailTopologyProxy(BasicHttpBinding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        { }

        public IList<FriendDTO> ProvideTopologyInput()
        {
            return base.Channel.ProvideTopologyInput();
        }
    }
}
