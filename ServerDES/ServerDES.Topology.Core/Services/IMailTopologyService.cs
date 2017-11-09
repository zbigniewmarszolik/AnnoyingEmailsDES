using ServerDES.Topology.Core.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServerDES.Topology.Core.Services
{
    [ServiceContract]
    public interface IMailTopologyService
    {
        [OperationContract]
        IList<FriendDTO> ProvideTopologyInput();
    }
}
