using ServerDES.Scenario.Core.Managers;
using System.IO;
using System.Reflection;

namespace ServerDES.Scenario.Data.Managers
{
    /*
     * ScenarioFileManager's implementation.
     */
    public class ScenarioFileManager : IScenarioFileManager
    {
        public string[] LoadScenarioInput()
        {
            string[] separatedLine = null;

            using (StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\scenario.txt"))
            {
                var singleLine = "";

                if ((singleLine = reader.ReadLine()) != null)
                {
                    separatedLine = singleLine.Split(' ');
                }
            }

            return separatedLine;
        }
    }
}
