using System.Collections.Generic;

namespace ServerDES.Topology.Core.Managers
{
    /*
     * TopologyFileManager's interface.
     */
    public interface ITopologyFileManager
    {
        IList<string[]> LoadFriendsTopology();
    }
}
