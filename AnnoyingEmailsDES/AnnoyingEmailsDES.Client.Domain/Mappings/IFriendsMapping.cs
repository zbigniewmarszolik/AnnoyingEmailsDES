using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Models;

namespace AnnoyingEmailsDES.Client.Domain.Mappings
{
    /*
     * FriendsMapping's interface.
     */
    public interface IFriendsMapping
    {
        FriendDTO ModelToDataTransferObject(Friend friend);
        Friend DataTransferObjectToModel(FriendDTO friendDto);
    }
}
