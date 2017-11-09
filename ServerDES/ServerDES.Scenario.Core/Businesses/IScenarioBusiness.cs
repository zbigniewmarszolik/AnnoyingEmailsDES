using ServerDES.Scenario.Core.Models;

namespace ServerDES.Scenario.Core.Businesses
{
    public interface IScenarioBusiness
    {
        Mail GetAndPrepareFirstScenario();
    }
}
