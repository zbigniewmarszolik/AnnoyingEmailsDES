using System.Collections.Generic;
using SignalRDES.Core.Managers;
using System.IO;
using System.Reflection;

namespace SignalRDES.Data.Managers
{
    /*
     * MailSimulatorFileManager's implementation.
     */
    public class MailSimulatorFileManager : IMailSimulatorFileManager
    {
        public IList<string[]> LoadTopologyInput()
        {
            IList<string[]> fileLines = new List<string[]>();

            using (StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\topology.txt"))
            {
                var singleLine = "";
                string[] separatedLine = null;

                while ((singleLine = reader.ReadLine()) != null)
                {
                    separatedLine = singleLine.Split(' ');
                    fileLines.Add(separatedLine);
                }
            }

            return fileLines;
        }

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
