using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AnnoyingEmailsDES.Client.Services.Contracts
{
    /*
     * Remote WCF service contract for scenario input.
     */
    [ServiceContract]
    public interface IMailScenarioService
    {
        [OperationContract]
        Task<MailDTO> ProvideScenarioInputAsync();
    }
}
