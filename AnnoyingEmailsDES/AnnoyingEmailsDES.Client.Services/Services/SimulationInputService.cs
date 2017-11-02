using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AnnoyingEmailsDES.Client.Domain.Services;
using AnnoyingEmailsDES.Client.Services.Proxies;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AnnoyingEmailsDES.Client.Services.Services
{
    /*
     * Implementation of SimulationInputService (communication with WCF server).
     */
    public class SimulationInputService : ServiceBase, ISimulationInputService
    {
        public Action ServerErrorAction { get; set; }

        private readonly IFriendsMapping _friendsMapping;
        private readonly IMailsMapping _mailsMapping;

        public SimulationInputService
            (IFriendsMapping friendsMapping, IMailsMapping mailsMapping) : base()
        {
            _friendsMapping = friendsMapping;
            _mailsMapping = mailsMapping;
        }

        public async Task<IList<Friend>> GetAllGroupMembers()
        {
            var client = new MailSimulationProxy(Binding, Address);

            IList<FriendDTO> dtos = null;
            IList<Friend> models = new List<Friend>();

            await Task.Run(() =>
            {
                try
                {
                    dtos = client.ProvideTopologyInput();
                }
                catch(Exception e)
                {
                    ServerErrorAction();
                }
            });

            foreach(var item in dtos)
            {
                var model = _friendsMapping.DataTransferObjectToModel(item);

                models.Add(model);
            }

            return models;
        }

        public async Task<Mail> GetStartingScenario()
        {
            var client = new MailSimulationProxy(Binding, Address);

            MailDTO dto = null;

            await Task.Run(() =>
            {
                try
                {
                    dto = client.ProvideScenarioInput();
                }
                catch(Exception e)
                {
                    ServerErrorAction();
                }
            });

            var model = _mailsMapping.DataTransferObjectToModel(dto);

            return model;
        }
    }
}
