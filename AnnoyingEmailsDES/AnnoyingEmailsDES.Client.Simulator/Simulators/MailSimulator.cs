using AnnoyingEmailsDES.Client.Domain.Models;
using AnnoyingEmailsDES.Client.Domain.Simulators;
using System;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Simulator.Simulators
{
    /*
     * Implementation of MailSimulator.
     */
    public class MailSimulator : IMailSimulator
    {
        public IList<Mail> SendMessage(IList<Friend> previousReceivers, int idCounter)
        {
            var nextMails = new List<Mail>();

            foreach (var item in previousReceivers) // processing all that received last message
            {
                if (item.WillContinue && item.FutureRecipients.Count > 0) // if person decided to follow and has recipients
                {
                    foreach (var j in item.FutureRecipients) // sending to all selected contacts
                    {
                        var newMail = new Mail
                        {
                            Id = idCounter + 1,
                            SenderId = item.Id,
                            ReceiverId = j
                        };

                        idCounter++; // for custom MailID incrementation

                        nextMails.Add(newMail);
                    }
                }

                else if (!item.WillContinue || item.FutureRecipients.Count == 0) // if person refused to follow, or has no recipients, setting for him the "ignore"
                {
                    var newMail = new Mail
                    {
                        Id = idCounter + 1,
                        SenderId = item.Id,
                        ReceiverId = 0
                    };

                    idCounter++; // for custom MailID incrementation

                    nextMails.Add(newMail);
                }
            }

            return nextMails;
        }

        public Friend ModifyReceiver(Friend friend, int groupSize)
        {
            var random = new Random();

            if (!friend.IsFirstPostOnWall) // if it is just first mail to him, then setting hated contact and condition to true, so will not do it again
            {
                friend.HatedContact = friend.Author;
                friend.IsFirstPostOnWall = true;
            }

            if (friend.LovedContact == friend.Author) // if received from loved contact, then it becomes hated
            {
                friend.HatedContact = friend.LovedContact;
                friend.LovedContact = friend.Contacts[random.Next(friend.Contacts.Count)];

                while (friend.HatedContact == friend.LovedContact) // random generating new loved contact, but different than the hated contact
                    friend.LovedContact = friend.Contacts[random.Next(friend.Contacts.Count)];
            }

            double forwardProbability = (double)friend.Contacts.Count / groupSize; // probability P = M/N

            var number = random.NextDouble();

            if (number < forwardProbability) // if will forward the message (the lower number, the biggest chance in case of high P)
            {
                friend.WillContinue = true;

                var futureRecipientsAmount = (int)Math.Round(forwardProbability * friend.Contacts.Count); // amount of forwards P*M

                if (futureRecipientsAmount == 0) // safe exit case if there is recipients amount equal to 0
                {
                    friend.WillContinue = false;
                    friend.FutureRecipients.Clear();

                    return friend;
                }

                IList<int> listToChooseFrom = new List<int>();

                foreach (var item in friend.Contacts)
                    listToChooseFrom.Add(item);

                listToChooseFrom.Remove(friend.Author); // never sending back to author

                for (var i = 0; i < futureRecipientsAmount; i++)
                {
                    var freshRecipient = listToChooseFrom[random.Next(listToChooseFrom.Count)];
                    listToChooseFrom.Remove(freshRecipient); // adding 1 recipient, then removing him from available recipients (can not send 2 times to the same recipients in 1 wave)

                    if (freshRecipient != friend.LovedContact) // never sending to loved contact
                        friend.FutureRecipients.Add(freshRecipient);
                }

                if (friend.HatedContact != 0 && friend.HatedContact != friend.Author)
                {
                    if (!friend.FutureRecipients.Contains(friend.HatedContact)) // always sending to hated contact
                    {
                        friend.FutureRecipients.Remove(random.Next(friend.FutureRecipients.Count));
                        friend.FutureRecipients.Add(friend.HatedContact);
                    }
                }
            }

            else // if not forwarding the message
            {
                friend.WillContinue = false;
                friend.FutureRecipients.Clear();
            }

            return friend;
        }
    }
}
