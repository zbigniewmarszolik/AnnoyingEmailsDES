using System;

namespace AnnoyingEmailsDES.Client.Domain.ViewModels
{
    /*
     * HistoryViewModel's interface.
     */
    public interface IHistoryVM
    {
        Action DbErrorAction { get; set; }
    }
}
