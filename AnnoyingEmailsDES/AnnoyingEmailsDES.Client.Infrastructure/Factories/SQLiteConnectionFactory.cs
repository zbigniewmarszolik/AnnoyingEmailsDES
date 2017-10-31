using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Factories;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;

namespace AnnoyingEmailsDES.Client.Infrastructure.Factories
{
    /*
     * Implementation of generic factory for SQLiteConnection.
     */
    public class SQLiteConnectionFactory : IFactory<SQLiteConnection>
    {
        public SQLiteConnection Create()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), Path.Combine(ApplicationData.Current.LocalFolder.Path, "DMaS_Laboratory.db"));

            connection.CreateTable<SimulationEntity>();
            connection.CreateTable<MailEntity>();

            return connection;
        }
    }
}
