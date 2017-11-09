using AutoMapper;
using ServerDES.Scenario.Core.Businesses;
using ServerDES.Scenario.Core.DTOs;
using ServerDES.Scenario.Core.Models;
using ServerDES.Scenario.Core.Services;

namespace ServerDES.Scenario.Microservice.Services
{
    public class MailScenarioService : IMailScenarioService
    {
        private readonly IScenarioBusiness _scenarioBusiness;
        private readonly IMapper _mapper;

        public MailScenarioService(IScenarioBusiness scenarioBusiness, IMapper mapper)
        {
            _scenarioBusiness = scenarioBusiness;
            _mapper = mapper;
        }

        public MailDTO ProvideScenarioInput()
        {
            var mailScenario = _scenarioBusiness.GetAndPrepareFirstScenario();

            var mailDto = _mapper.Map<Mail, MailDTO>(mailScenario);

            return mailDto;
        }
    }
}
