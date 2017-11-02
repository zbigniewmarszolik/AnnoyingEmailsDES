using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Models;
using AutoMapper;

namespace AnnoyingEmailsDES.Client.Mapper.Profiles
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Mail, MailDTO>();
            CreateMap<MailDTO, Mail>();

            CreateMap<Friend, FriendDTO>();
            CreateMap<FriendDTO, Friend>();
        }
    }
}
