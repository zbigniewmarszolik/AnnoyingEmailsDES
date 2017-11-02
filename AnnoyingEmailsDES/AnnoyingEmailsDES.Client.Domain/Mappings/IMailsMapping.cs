using AnnoyingEmailsDES.Client.Domain.DTOs;
using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Models;

namespace AnnoyingEmailsDES.Client.Domain.Mappings
{
    /*
     * MailsMapping's interface.
     */
    public interface IMailsMapping
    {
        MailDTO ModelToDataTransferObject(Mail mail);
        Mail DataTransferObjectToModel(MailDTO mailDto);
        MailEntity ModelToEntity(Mail mail);
    }
}
