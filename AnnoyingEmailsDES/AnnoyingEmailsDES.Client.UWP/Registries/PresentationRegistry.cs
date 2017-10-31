using AnnoyingEmailsDES.Client.Domain.ViewModels;
using AnnoyingEmailsDES.Client.UWP.Helpers;
using AnnoyingEmailsDES.Client.UWP.ViewModels;
using StructureMap;

namespace AnnoyingEmailsDES.Client.UWP.Registries
{
    /*
     * Class responsible for registering the Application Layer classes in StructureMap container.
     */
    public class PresentationRegistry : Registry
    {
        public PresentationRegistry()
        {
            For<FriendsHelper>().Use<FriendsHelper>();
            For<MailsHelper>().Use<MailsHelper>();

            For<IHistoryVM>().Use<HistoryVM>();
            For<ISimulationVM>().Use<SimulationVM>();
        }
    }
}
