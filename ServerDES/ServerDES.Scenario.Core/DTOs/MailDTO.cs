using System.Runtime.Serialization;

namespace ServerDES.Scenario.Core.DTOs
{
    /*
     * Mail Data Transfer Object.
     */
    [DataContract(Namespace = "des.mail")]
    public class MailDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ReceiverId { get; set; }
        [DataMember]
        public int SenderId { get; set; }
    }
}
