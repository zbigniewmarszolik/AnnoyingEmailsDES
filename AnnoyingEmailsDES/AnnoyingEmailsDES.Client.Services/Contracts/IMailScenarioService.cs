using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.ServiceModel;

namespace AnnoyingEmailsDES.Client.Services.Contracts
{
    /*
     * Remote WCF service contract for scenario input.
     */
    [ServiceContract]
    public interface IMailScenarioService
    {
        [OperationContract]
        MailDTO ProvideScenarioInput();
    }
}
