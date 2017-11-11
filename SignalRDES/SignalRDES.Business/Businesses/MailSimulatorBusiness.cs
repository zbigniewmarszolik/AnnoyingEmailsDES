using System.Collections.Generic;
using SignalRDES.Core.Businesses;
using SignalRDES.Core.Models;
using System.Linq;
using SignalRDES.Core.Managers;

namespace SignalRDES.Business.Businesses
{
    public class MailSimulatorBusiness : IMailSimulatorBusiness
    {
        private readonly IMailSimulatorFileManager _fileManager;

        public MailSimulatorBusiness(IMailSimulatorFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public IList<Friend> GetAndPrepareTopology()
        {
            IList<string[]> unparsedDataList = null;

            unparsedDataList = _fileManager.LoadTopologyInput();

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

        public Mail GetAndPrepareScenario()
        {
            string[] unparsedMsgData = null;

            unparsedMsgData = _fileManager.LoadScenarioInput();

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
