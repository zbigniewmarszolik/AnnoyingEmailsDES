using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace AnnoyingEmailsDES.Client.Services.Contracts
{
    /*
     * Remote WCF service contract for topology input.
     */
    [ServiceContract]
    public interface IMailTopologyService
    {
        [OperationContract]
        IList<FriendDTO> ProvideTopologyInput();
    }
}
