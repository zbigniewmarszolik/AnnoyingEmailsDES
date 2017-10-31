using AnnoyingEmailsDES.Client.Domain.Models;
using System;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.UWP.Helpers
{
    /*
     * Class responsible for initiating the Friend model and generating its loved contact.
     */
    public class FriendsHelper
    {
        public Friend AssignFriendProperties(Friend friend)
        {
            friend.Author = 0;
            friend.HatedContact = 0;
            friend.FutureRecipients = new List<int>();
            friend.IsFirstPostOnWall = false;

            var random = new Random();

            friend.LovedContact = friend.Contacts[random.Next(friend.Contacts.Count)]; // choosing random loved contact

            while (friend.HatedContact == friend.LovedContact) // will be choosing the random loved until it is different than the hated contact
                friend.HatedContact = friend.Contacts[random.Next(friend.Contacts.Count)];

            return friend;
        }
    }
}
