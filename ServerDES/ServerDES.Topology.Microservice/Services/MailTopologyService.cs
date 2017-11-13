using System.Collections.Generic;
using ServerDES.Topology.Core.DTOs;
using ServerDES.Topology.Core.Services;
using AutoMapper;
using ServerDES.Topology.Core.Businesses;
using ServerDES.Topology.Core.Models;
using System.Threading.Tasks;

namespace ServerDES.Topology.Microservice.Services
{
    /*
     * MailTopologyService contract's implementation.
     */
    public class MailTopologyService : IMailTopologyService
    {
        private readonly ITopologyBusiness _topologyBusiness;
        private readonly IMapper _mapper;

        public MailTopologyService(ITopologyBusiness topologyBusiness, IMapper mapper)
        {
            _topologyBusiness = topologyBusiness;
            _mapper = mapper;
        }

        public async Task<IList<FriendDTO>> ProvideTopologyInputAsync()
        {
            var topologySet = await _topologyBusiness.GetAndPrepareTopologyAsync();

            IList<FriendDTO> friendDtos = new List<FriendDTO>();

            foreach(var item in topologySet)
            {
                var dto = _mapper.Map<Friend, FriendDTO>(item);
                friendDtos.Add(dto);
            }

            return friendDtos;
        }
    }
}
