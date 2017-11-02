using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Domain.Entities
{
    /*
     * Simulation data object.
     */
    [Table("Simulations")]
    public class SimulationEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public DateTime SimulationDate { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<MailEntity> Mails { get; set; }
    }
}
