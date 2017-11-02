using System.Collections.Generic;

namespace ServerDES.Core.Models
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
