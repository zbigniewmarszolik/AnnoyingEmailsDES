using System.Collections.Generic;
using SignalRDES.Core.Services;
using SignalRDES.Core.Businesses;
using SignalRDES.Core.DataTransferObjects;

namespace SignalRDES.Service.Services
{
    /*
     * MailSimulatorService's implementation.
     */
    public class MailSimulatorService : IMailSimulatorService
    {
        private readonly IMailSimulatorBusiness _mailSimulatorBusiness;

        public MailSimulatorService(IMailSimulatorBusiness mailSimulatorBusiness)
        {
            _mailSimulatorBusiness = mailSimulatorBusiness;
        }

        public IList<FriendDTO> ProvideTopologyInput()
        {
            var topologySet = _mailSimulatorBusiness.GetAndPrepareTopology();

            IList<FriendDTO> friendDtos = new List<FriendDTO>();

            foreach(var item in topologySet)
            {
                friendDtos.Add(item.ToTransfer());
            }

            return friendDtos;
        }

        public MailDTO ProvideScenarioInput()
        {
            var mailScenario = _mailSimulatorBusiness.GetAndPrepareScenario();

            var mailDto = mailScenario.ToTransfer();

            return mailDto;
        }
    }
}
