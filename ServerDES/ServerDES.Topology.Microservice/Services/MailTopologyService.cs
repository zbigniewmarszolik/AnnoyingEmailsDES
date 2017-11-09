using System.Collections.Generic;
using ServerDES.Topology.Core.DTOs;
using ServerDES.Topology.Core.Services;
using AutoMapper;
using ServerDES.Topology.Core.Businesses;
using ServerDES.Topology.Core.Models;

namespace ServerDES.Topology.Microservice.Services
{
    public class MailTopologyService : IMailTopologyService
    {
        private readonly ITopologyBusiness _topologyBusiness;
        private readonly IMapper _mapper;

        public MailTopologyService(ITopologyBusiness topologyBusiness, IMapper mapper)
        {
            _topologyBusiness = topologyBusiness;
            _mapper = mapper;
        }

        public IList<FriendDTO> ProvideTopologyInput()
        {
            var topologySet = _topologyBusiness.GetAndPrepareTopology();

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
