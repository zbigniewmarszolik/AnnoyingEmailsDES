namespace AnnoyingEmailsDES.Client.UWP.Helpers
{
    /*
      * Class responsible for converting receiverId of Mail equal 0 to string "!!! ignored !!!".
      */
    public class MailsHelper
    {
        public string SetReceiverValue(double recId)
        {
            if (recId != 0)
                return recId.ToString();

            else return "!!! ignored !!!";
        }
    }
}
