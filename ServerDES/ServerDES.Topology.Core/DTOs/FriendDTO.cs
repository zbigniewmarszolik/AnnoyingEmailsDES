using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerDES.Topology.Core.DTOs
{
    /*
     * Friend Data Transfer Object.
     */
    [DataContract(Namespace = "des.friend")]
    public class FriendDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public IList<int> Contacts { get; set; }
    }
}
