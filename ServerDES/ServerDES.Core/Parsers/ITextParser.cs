using ServerDES.Core.Models;
using System.Collections.Generic;

namespace ServerDES.Core.Parsers
{
    /*
     * TextParser's interface.
     */
    public interface ITextParser
    {
        IList<Friend> ParseFriendsTopology(IList<string[]> unparsedFriendsData);
        Mail ParseFirstMessageScenario(string[] unparsedMsgData);
    }
}
