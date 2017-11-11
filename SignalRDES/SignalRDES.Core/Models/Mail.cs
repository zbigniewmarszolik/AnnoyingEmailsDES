using SignalRDES.Core.DataTransferObjects;

namespace SignalRDES.Core.Models
{
    /*
     * Mail model class.
     */
    public class Mail
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }

        public MailDTO ToTransfer()
        {
            var dto = new MailDTO();

            dto.Id = Id;
            dto.SenderId = SenderId;
            dto.ReceiverId = ReceiverId;

            return dto;
        }
    }
}
