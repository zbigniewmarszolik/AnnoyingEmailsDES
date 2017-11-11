using System.Collections.Generic;

namespace SignalRDES.Core.Managers
{
    public interface IMailSimulatorFileManager
    {
        IList<string[]> LoadTopologyInput();
        string[] LoadScenarioInput();
    }
}
