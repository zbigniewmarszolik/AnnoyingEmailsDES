using SignalRDES.Core.DataTransferObjects;
using System.Collections.Generic;

namespace SignalRDES.Core.Models
{
    /*
    * Friend model class.
    */
    public class Friend
    {
        public int Id { get; set; }
        public IList<int> Contacts { get; set; }

        public FriendDTO ToTransfer()
        {
            var dto = new FriendDTO();
            dto.Id = Id;
            dto.Contacts = new List<int>();

            foreach (var item in Contacts)
            {
                dto.Contacts.Add(item);
            }

            return dto;
        }
    }
}
