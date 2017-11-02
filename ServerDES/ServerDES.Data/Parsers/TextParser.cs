using ServerDES.Core.Models;
using ServerDES.Core.Parsers;
using System.Collections.Generic;
using System.Linq;

namespace ServerDES.Data.Parsers
{
    /*
     * Implementation of TextParser.
     */
    public class TextParser : ITextParser
    {
        //Method which parses topology input based on the content read by FileManager.
        public IList<Friend> ParseFriendsTopology(IList<string[]> unparsedDataList)
        {
            IList<Friend> FriendsGroup = new List<Friend>();
            IList<int> contactsList = null;
            var friendsAmount = 0;

            friendsAmount = int.Parse(unparsedDataList.ElementAt(0).ElementAt(0));

            for (int i = 1; i <= friendsAmount; i++)
            {
                contactsList = new List<int>();

                int k = unparsedDataList.ElementAt(i).Length;

                for (int j = 1; j < k; j++)
                {
                    contactsList.Add(int.Parse(unparsedDataList.ElementAt(i).ElementAt(j)));
                }

                var friend = new Friend
                {
                    Id = i,
                    Contacts = contactsList
                };

                FriendsGroup.Add(friend);
            }

            return FriendsGroup;
        }

        //Method which parses scenario input based on the content read by FileManager.
        public Mail ParseFirstMessageScenario(string[] unparsedMsgData)
        {
            var originalSenderId = 0;
            var originalReceiverId = 0;

            originalSenderId = int.Parse(unparsedMsgData[0]);
            originalReceiverId = int.Parse(unparsedMsgData[1]);

            var firstMail = new Mail
            {
                Id = 1,
                SenderId = originalSenderId,
                ReceiverId = originalReceiverId
            };

            return firstMail;
        }
    }
}
