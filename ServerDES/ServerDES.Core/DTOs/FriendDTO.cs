using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerDES.Core.DTOs
{
    /*
     * Friend Data Transfer Object.
     */
    [DataContract(Namespace = "wcf.des")]
    public class FriendDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public IList<int> Contacts { get; set; }
    }
}
