using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AnnoyingEmailsDES.Client.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.ServiceModel;
using AnnoyingEmailsDES.Client.Services.Proxies;

namespace AnnoyingEmailsDES.Client.Services.Services
{
    /*
     * Implementation of SimulationInputService (communication with WCF server).
     */
    public class SimulationInputService : ServiceBase, ISimulationInputService
    {
        public Action ServerErrorAction { get; set; }

        private EndpointAddress _topologyEndpointAddress;
        private EndpointAddress _scenarioEndpointAddress;

        private readonly IFriendsMapping _friendsMapping;
        private readonly IMailsMapping _mailsMapping;

        public SimulationInputService
            (IFriendsMapping friendsMapping, IMailsMapping mailsMapping) : base()
        {
            _friendsMapping = friendsMapping;
            _mailsMapping = mailsMapping;

            _topologyEndpointAddress = new EndpointAddress("http://localhost:8000/AnnoyingEmailsTopology/");
            _scenarioEndpointAddress = new EndpointAddress("http://localhost:8001/AnnoyingEmailsScenario/");
        }

        public async Task<IList<Friend>> GetAllGroupMembers()
        {
            var client = new MailTopologyProxy(Binding, _topologyEndpointAddress);

            IList<FriendDTO> dtos = null;
            IList<Friend> models = new List<Friend>();

            try
            {
                dtos = await client.ProvideTopologyInputAsync();
            }
            catch (Exception e)
            {
                ServerErrorAction();
            }

            foreach (var item in dtos)
            {
                var model = _friendsMapping.DataTransferObjectToModel(item);

                models.Add(model);
            }

            return models;
        }

        public async Task<Mail> GetStartingScenario()
        {
            var client = new MailScenarioProxy(Binding, _scenarioEndpointAddress);

            MailDTO dto = null;

            try
            {
                dto = await client.ProvideScenarioInputAsync();
            }
            catch (Exception e)
            {
                ServerErrorAction();
            }

            var model = _mailsMapping.DataTransferObjectToModel(dto);

            return model;
        }
    }
}
