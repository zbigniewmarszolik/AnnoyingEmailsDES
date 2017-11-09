using AutoMapper;
using ServerDES.Scenario.Core.DTOs;
using ServerDES.Scenario.Core.Models;
using ServerDES.Topology.Core.DTOs;
using ServerDES.Topology.Core.Models;

namespace ServerDES.CommonServiceBus.Factories
{
    /*
     * AutoMapper factory.
     */
    public class AutoMapperFactory
    {
        public IMapper ProduceMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Mail, MailDTO>();
                c.CreateMap<MailDTO, Mail>();

                c.CreateMap<Friend, FriendDTO>();
                c.CreateMap<FriendDTO, Friend>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
