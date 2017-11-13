using ServerDES.Scenario.Core.DTOs;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServerDES.Scenario.Core.Services
{
    /*
     * MailScenarioService's service contract.
     */
    [ServiceContract]
    public interface IMailScenarioService
    {
        [OperationContract]
        Task<MailDTO> ProvideScenarioInputAsync();
    }
}
