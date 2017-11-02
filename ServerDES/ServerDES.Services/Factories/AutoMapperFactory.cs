using AutoMapper;
using ServerDES.Core.DTOs;
using ServerDES.Core.Models;

namespace ServerDES.Services.Factories
{
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
