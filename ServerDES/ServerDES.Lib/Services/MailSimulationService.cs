using System.Collections.Generic;
using ServerDES.Core.Services;
using ServerDES.Core.DTOs;

namespace ServerDES.Lib.Services
{
    /*
     * Implementation of MailSimulationService.
     */
    public class MailSimulationService : IMailSimulationService
    {
        public IList<FriendDTO> ProvideTopologyInput()
        {
            var friends = new List<FriendDTO>();

            friends = FillList(friends);

            return friends;
        }

        public MailDTO ProvideScenarioInput()
        {
            var mail = new MailDTO
            {
                Id = 1,
                SenderId = 1,
                ReceiverId = 2
            };

            return mail;
        }

        private List<FriendDTO> FillList(List<FriendDTO> friends)
        {
            var one = new FriendDTO
            {
                Id = 1,
                Contacts = new List<int>()
                {
                    2,
                    4
                }
            };
            var two = new FriendDTO
            {
                Id = 2,
                Contacts = new List<int>()
                {
                    1,
                    3,
                    4
                }
            };
            var three = new FriendDTO
            {
                Id = 3,
                Contacts = new List<int>()
                {
                    1,
                    2,
                    4
                }
            };
            var four = new FriendDTO
            {
                Id = 4,
                Contacts = new List<int>()
                {
                    1,
                    2
                }
            };

            friends.Add(one);
            friends.Add(two);
            friends.Add(three);
            friends.Add(four);

            return friends;
        }
    }
}
