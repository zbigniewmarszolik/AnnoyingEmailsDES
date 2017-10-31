using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Domain.Models
{
    /*
     * Friend model class.
     */
    public class Friend
    {
        public int Id { get; set; }
        public IList<int> Contacts { get; set; }
        public int HatedContact { get; set; }
        public int LovedContact { get; set; }
        public int Author { get; set; } // author of arriving mail
        public bool WillContinue { get; set; } // if ignored
        public IList<int> FutureRecipients { get; set; } // if did not ignore, the amount of recipients in next wave
        public bool IsFirstPostOnWall { get; set; } // if first mail arrived and the hated contact is arranged
    }
}
