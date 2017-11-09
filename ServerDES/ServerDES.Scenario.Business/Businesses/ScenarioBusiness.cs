using ServerDES.Scenario.Core.Businesses;
using ServerDES.Scenario.Core.Managers;
using ServerDES.Scenario.Core.Models;
using System.Threading.Tasks;

namespace ServerDES.Scenario.Business.Businesses
{
    public class ScenarioBusiness : IScenarioBusiness
    {
        private readonly IScenarioFileManager _scenarioFileManager;

        public ScenarioBusiness(IScenarioFileManager scenarioFileManager)
        {
            _scenarioFileManager = scenarioFileManager;
        }

        public async Task<Mail> GetAndPrepareFirstScenarioAsync()
        {
            string[] unparsedMsgData = null;

            await Task.Run(() =>
            {
                unparsedMsgData = _scenarioFileManager.LoadScenarioInput();
            });

            var originalSenderId = 0;
            var originalReceiverId = 0;

            originalSenderId = int.Parse(unparsedMsgData[0]);
            originalReceiverId = int.Parse(unparsedMsgData[1]);

            var firstMail = new Mail
            {
                Id = 1,
                SenderId = originalSenderId,
                ReceiverId = originalReceiverId
            };

            return firstMail;
        }
    }
}
