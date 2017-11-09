using ServerDES.Scenario.Core.DTOs;
using System.ServiceModel;

namespace ServerDES.Scenario.Core.Services
{
    [ServiceContract]
    public interface IMailScenarioService
    {
        [OperationContract]
        MailDTO ProvideScenarioInput();
    }
}
