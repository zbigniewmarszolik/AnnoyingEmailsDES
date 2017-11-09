using ServerDES.Topology.Core.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServerDES.Topology.Core.Services
{
    [ServiceContract]
    public interface IMailTopologyService
    {
        [OperationContract]
        Task<IList<FriendDTO>> ProvideTopologyInputAsync();
    }
}
