using System.Collections.Generic;

namespace ServerDES.Topology.Core.Models
{
    /*
    * Friend model class.
    */
    public class Friend
    {
        public int Id { get; set; }
        public IList<int> Contacts { get; set; }
    }
}
