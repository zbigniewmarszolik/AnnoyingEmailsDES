using ServerDES.Topology.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerDES.Topology.Core.Businesses
{
    public interface ITopologyBusiness
    {
        Task<IList<Friend>> GetAndPrepareTopologyAsync();
    }
}
