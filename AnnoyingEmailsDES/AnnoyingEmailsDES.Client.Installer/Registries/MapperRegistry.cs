using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Mapper.Mappings;
using AutoMapper;
using StructureMap;
using AnnoyingEmailsDES.Client.Mapper.Profiles;

namespace AnnoyingEmailsDES.Client.Installer.Registries
{
    /*
     * Class responsible for registering the Mapper classes in StructureMap container.
     */
    public class MapperRegistry : Registry
    {
        private IMapper _mapper { get; set; }

        public MapperRegistry()
        {
            InitializeMapper();

            For<IFriendsMapping>().Use<FriendsMapping>();
            For<IMailsMapping>().Use<MailsMapping>();

            For<IMapper>().Use(_mapper).Singleton();
        }

        private void InitializeMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<ServicesProfile>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
