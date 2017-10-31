using AnnoyingEmailsDES.Client.Domain.Models;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Domain.Simulators
{
    /*
     * MailSimulator's interface.
     */
    public interface IMailSimulator
    {
        IList<Mail> SendMessage(IList<Friend> previousReceivers, int idCounter);
        Friend ModifyReceiver(Friend friend, int groupSize);
    }
}
