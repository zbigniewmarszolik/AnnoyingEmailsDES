using ServerDES.Topology.Core.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServerDES.Topology.Core.Services
{
    /*
     * MailTopologyService's service contract.
     */
    [ServiceContract]
    public interface IMailTopologyService
    {
        [OperationContract]
        Task<IList<FriendDTO>> ProvideTopologyInputAsync();
    }
}
