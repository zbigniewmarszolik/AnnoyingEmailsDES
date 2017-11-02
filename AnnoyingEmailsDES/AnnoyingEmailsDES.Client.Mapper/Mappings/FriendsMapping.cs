using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AutoMapper;

namespace AnnoyingEmailsDES.Client.Mapper.Mappings
{
    /*
     * Implementation of FriendsMapping.
     */
    public class FriendsMapping : IFriendsMapping
    {
        private readonly IMapper _mapper;

        public FriendsMapping(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Friend DataTransferObjectToModel(FriendDTO friendDto)
        {
            var friend = _mapper.Map<FriendDTO, Friend>(friendDto);

            return friend;
        }

        public FriendDTO ModelToDataTransferObject(Friend friend)
        {
            var friendDto = _mapper.Map<Friend, FriendDTO>(friend);

            return friendDto;
        }
    }
}
