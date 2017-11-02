using System;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Domain.Models
{
    /*
     * Simulation model class.
     */
    public class Simulation
    {
        public DateTime SimulationDate { get; set; }
        public List<Mail> Mails { get; set; }
    }
}
