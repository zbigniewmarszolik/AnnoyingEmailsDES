using System.Collections.Generic;

namespace ServerDES.Topology.Core.Managers
{
    public interface ITopologyFileManager
    {
        IList<string[]> LoadFriendsTopology();
    }
}
