using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Models;
using AutoMapper;

namespace AnnoyingEmailsDES.Client.Mapper.Profiles
{
    /*
     * Class with AutoMapper profiles.
     */
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Friend, FriendDTO>();
            CreateMap<FriendDTO, Friend>();

            CreateMap<Mail, MailDTO>();
            CreateMap<MailDTO, Mail>();


            CreateMap<Mail, MailEntity>().ForMember(x => x.InternalId, o => o.MapFrom(s => s.Id)).ForMember(y => y.Id, z => z.Ignore());
            CreateMap<MailEntity, Mail>().ForMember(x => x.Id, o => o.MapFrom(s => s.InternalId));

            CreateMap<Simulation, SimulationEntity>();
            CreateMap<SimulationEntity, Simulation>();
        }
    }
}
