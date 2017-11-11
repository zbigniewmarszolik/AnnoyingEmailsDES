using SignalRDES.Core.Models;
using System.Collections.Generic;

namespace SignalRDES.Core.Businesses
{
    public interface IMailSimulatorBusiness
    {
        IList<Friend> GetAndPrepareTopology();
        Mail GetAndPrepareScenario();
    }
}
