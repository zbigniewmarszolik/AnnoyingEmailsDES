using ServerDES.Scenario.Core.DTOs;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServerDES.Scenario.Core.Services
{
    [ServiceContract]
    public interface IMailScenarioService
    {
        [OperationContract]
        Task<MailDTO> ProvideScenarioInputAsync();
    }
}
