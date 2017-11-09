using System.Collections.Generic;
using ServerDES.Topology.Core.Managers;
using System.IO;
using System.Reflection;

namespace ServerDES.Topology.Data.Managers
{
    public class TopologyFileManager : ITopologyFileManager
    {
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
    }
}
