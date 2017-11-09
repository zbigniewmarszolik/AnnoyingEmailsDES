using ServerDES.Scenario.Core.Models;
using System.Threading.Tasks;

namespace ServerDES.Scenario.Core.Businesses
{
    public interface IScenarioBusiness
    {
        Task<Mail> GetAndPrepareFirstScenarioAsync();
    }
}
