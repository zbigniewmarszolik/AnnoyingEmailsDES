using System.Collections.Generic;

namespace ServerDES.Core.Managers
{
    /*
     * FileManager's interface.
     */
    public interface IFileManager
    {
        IList<string[]> LoadFriendsTopology();
        string[] LoadFirstMessageScenario();
    }
}
