namespace AnnoyingEmailsDES.Client.Domain.Models
{
    /*
     * Mail model class.
     */
    public class Mail
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public string ReceiverValue { get; set; } // just for view's purposes, to handle "ignored" value
    }
}
