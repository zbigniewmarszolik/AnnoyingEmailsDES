﻿using System.Runtime.Serialization;

namespace AnnoyingEmailsDES.Client.Domain.DTOs
{
    /*
     * Friend Data Transfer Object.
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
