using AutoMapper;
using ServerDES.Scenario.Core.Businesses;
using ServerDES.Scenario.Core.DTOs;
using ServerDES.Scenario.Core.Models;
using ServerDES.Scenario.Core.Services;
using System.Threading.Tasks;

namespace ServerDES.Scenario.Microservice.Services
{
    /*
     * MailScenarioService contract's implementation.
     */
    public class MailScenarioService : IMailScenarioService
    {
        private readonly IScenarioBusiness _scenarioBusiness;
        private readonly IMapper _mapper;

        public MailScenarioService(IScenarioBusiness scenarioBusiness, IMapper mapper)
        {
            _scenarioBusiness = scenarioBusiness;
            _mapper = mapper;
        }

        public async Task<MailDTO> ProvideScenarioInputAsync()
        {
            var mailScenario = await _scenarioBusiness.GetAndPrepareFirstScenarioAsync();

            var mailDto = _mapper.Map<Mail, MailDTO>(mailScenario);

            return mailDto;
        }
    }
}
