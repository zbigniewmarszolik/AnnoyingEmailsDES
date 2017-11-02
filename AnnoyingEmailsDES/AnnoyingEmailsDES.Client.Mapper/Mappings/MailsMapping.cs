using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Mappings;
using AnnoyingEmailsDES.Client.Domain.Models;
using AutoMapper;

namespace AnnoyingEmailsDES.Client.Mapper.Mappings
{
    /*
     * Implementation of MailsMapping.
     */
    public class MailsMapping : IMailsMapping
    {
        private readonly IMapper _mapper;

        public MailsMapping(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Mail DataTransferObjectToModel(MailDTO mailDto)
        {
            var mail = _mapper.Map<MailDTO, Mail>(mailDto);

            return mail;
        }

        public MailDTO ModelToDataTransferObject(Mail mail)
        {
            var mailDto = _mapper.Map<Mail, MailDTO>(mail);

            return mailDto;
        }

        public MailEntity ModelToEntity(Mail mail)
        {
            var mailEntity = _mapper.Map<Mail, MailEntity>(mail);

            return mailEntity;
        }
    }
}
