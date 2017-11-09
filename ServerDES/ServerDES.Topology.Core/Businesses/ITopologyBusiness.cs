using ServerDES.Topology.Core.Models;
using System.Collections.Generic;

namespace ServerDES.Topology.Core.Businesses
{
    public interface ITopologyBusiness
    {
        IList<Friend> GetAndPrepareTopology();
    }
}
