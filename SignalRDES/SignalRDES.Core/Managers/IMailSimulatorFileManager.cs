using System.Collections.Generic;

namespace SignalRDES.Core.Managers
{
    /*
     * MailSimulatorFileManager's interface.
     */
    public interface IMailSimulatorFileManager
    {
        IList<string[]> LoadTopologyInput();
        string[] LoadScenarioInput();
    }
}
