using System.Collections.Generic;

namespace SignalRDES.Core.DataTransferObjects
{
    /*
     * Friend Data Transfer Object.
     */
    public class FriendDTO
    {
        public int Id { get; set; }
        public IList<int> Contacts { get; set; }
    }
}
