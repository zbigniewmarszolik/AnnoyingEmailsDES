using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AnnoyingEmailsDES.Client.Services.Contracts
{
    /*
     * Remote WCF service contract for topology input.
     */
    [ServiceContract]
    public interface IMailTopologyService
    {
        [OperationContract]
        Task<IList<FriendDTO>> ProvideTopologyInputAsync();
    }
}
