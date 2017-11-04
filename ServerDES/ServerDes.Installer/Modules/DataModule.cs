using Autofac;
using ServerDES.Core.Managers;
using ServerDES.Core.Parsers;
using ServerDES.Data.Managers;
using ServerDES.Data.Parsers;

namespace ServerDes.Installer.Modules
{
    /*
     * Autofac module for Data layer.
     */
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileManager>().As<IFileManager>();
            builder.RegisterType<TextParser>().As<ITextParser>();
        }
    }
}
