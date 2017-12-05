using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace AnnoyingEmailsDES.Client.Domain.Entities
{
    /*
     * Mail data object.
     */
    [Table("Mails")]
    public class MailEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public int InternalId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [ManyToOne]
        public SimulationEntity Simulation { get; set; }

        [ForeignKey(typeof(SimulationEntity))]
        public int SimId { get; set; }
    }
}
