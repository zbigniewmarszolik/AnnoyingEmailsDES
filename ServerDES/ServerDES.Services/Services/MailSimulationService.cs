using AutoMapper;
using ServerDES.Core.DTOs;
using ServerDES.Core.Managers;
using ServerDES.Core.Models;
using ServerDES.Core.Parsers;
using ServerDES.Core.Services;
using ServerDES.Data.Managers;
using ServerDES.Data.Parsers;
using ServerDES.Services.Factories;
using System.Collections.Generic;

namespace ServerDES.Services.Services
{
    /*
     * Implementation of MailSimulationService.
     */
    public class MailSimulationService : IMailSimulationService
    {
        private readonly IFileManager _fileManager;
        private readonly ITextParser _textParser;
        private readonly IMapper _mapper;
        private readonly AutoMapperFactory _mapperFactory;

        public MailSimulationService()
        {
            _fileManager = new FileManager();
            _textParser = new TextParser();
            _mapperFactory = new AutoMapperFactory();
            _mapper = _mapperFactory.ProduceMapper();
        }

        public IList<FriendDTO> ProvideTopologyInput()
        {
            var friendsDto = new List<FriendDTO>();

            var unparsedFriends = _fileManager.LoadFriendsTopology();
            var parsedFriends = _textParser.ParseFriendsTopology(unparsedFriends);

            foreach (var item in parsedFriends)
            {
                var dto = _mapper.Map<Friend, FriendDTO>(item);

                friendsDto.Add(dto);
            }

            return friendsDto;
        }

        public MailDTO ProvideScenarioInput()
        {
            var unparsedMailScenario = _fileManager.LoadFirstMessageScenario();
            var parsedMailScenario = _textParser.ParseFirstMessageScenario(unparsedMailScenario);

            var mailDto = _mapper.Map<Mail, MailDTO>(parsedMailScenario);

            return mailDto;
        }
    }
}
