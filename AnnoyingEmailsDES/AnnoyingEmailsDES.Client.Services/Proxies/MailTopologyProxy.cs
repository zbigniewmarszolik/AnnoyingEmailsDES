using AnnoyingEmailsDES.Client.Services.Contracts;
using System.ServiceModel;
using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnoyingEmailsDES.Client.Services.Proxies
{
    /*
     * Remote WCF service proxy for topology.
     */
    public class MailTopologyProxy : ClientBase<IMailTopologyService>, IMailTopologyService
    {
        public MailTopologyProxy(BasicHttpBinding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        { }

        public Task<IList<FriendDTO>> ProvideTopologyInputAsync()
        {
            return Channel.ProvideTopologyInputAsync();
        }
    }
}
