using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AutoMapper;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Mapper.Mappings
{
    /*
     * Implementation of SimulationsMapping.
     */
    public class SimulationsMapping : ISimulationsMapping
    {
        private readonly IMapper _mapper;

        public SimulationsMapping(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Simulation EntityToModel(SimulationEntity simulationDAO)
        {
            IList<Mail> tempMails = new List<Mail>();

            foreach(var item in simulationDAO.Mails)
            {
                var modelComponent = _mapper.Map<MailEntity, Mail>(item);

                tempMails.Add(modelComponent);
            }

            simulationDAO.Mails.Clear();

            var model = _mapper.Map<SimulationEntity, Simulation>(simulationDAO);

            foreach(var item in tempMails)
            {
                model.Mails.Add(item);
            }

            return model;
        }
    }
}
