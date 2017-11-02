using AnnoyingEmailsDES.Client.Domain.Models;
using System;
using System.Collections.ObjectModel;

namespace AnnoyingEmailsDES.Client.Domain.ViewModels
{
    /*
     * HistoryViewModel's interface.
     */
    public interface IHistoryVM
    {
        Action DbErrorAction { get; set; }

        ObservableCollection<Simulation> ObservableSimulations { get; set; }
    }
}
