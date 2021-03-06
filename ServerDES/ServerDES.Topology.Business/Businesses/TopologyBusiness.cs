﻿using System.Collections.Generic;
using ServerDES.Topology.Core.Businesses;
using ServerDES.Topology.Core.Models;
using ServerDES.Topology.Core.Managers;
using System.Linq;
using System.Threading.Tasks;

namespace ServerDES.Topology.Business.Businesses
{
    /*
     * TopologyBusiness's implementation.
     */
    public class TopologyBusiness : ITopologyBusiness
    {
        private readonly ITopologyFileManager _topologyFileManager;

        public TopologyBusiness(ITopologyFileManager topologyFileManager)
        {
            _topologyFileManager = topologyFileManager;
        }

        public async Task<IList<Friend>> GetAndPrepareTopologyAsync()
        {
            IList<string[]> unparsedDataList = null;

            await Task.Run(() =>
            {
                unparsedDataList = _topologyFileManager.LoadFriendsTopology();
            });

            IList<Friend> FriendsGroup = new List<Friend>();
            IList<int> contactsList = null;
            var friendsAmount = 0;

            friendsAmount = int.Parse(unparsedDataList.ElementAt(0).ElementAt(0));

            await Task.Run(() =>
            {
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
            });            

            return FriendsGroup;
        }
    }
}
