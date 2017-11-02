using ServerDES.Core.Managers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ServerDES.Data.Managers
{
    /*
     * Implementation of FileManager.
     */
    public class FileManager : IFileManager
    {
        //Method that reads topology input based on file path.
        public IList<string[]> LoadFriendsTopology()
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

        //Method that reads scenario input based on file path.
        public string[] LoadFirstMessageScenario()
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
