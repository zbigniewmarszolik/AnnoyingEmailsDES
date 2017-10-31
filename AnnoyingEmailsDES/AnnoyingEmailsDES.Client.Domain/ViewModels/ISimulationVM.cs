using AnnoyingEmailsDES.Client.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AnnoyingEmailsDES.Client.Domain.ViewModels
{
    /*
     * SimulatorViewModel's interface.
     */
    public interface ISimulationVM
    {
        Action DbErrorAction { get; set; }
        Action<IHistoryVM> HistoryAction { get; set; }

        ICommand ShowHistoryCommand { get; }
        ICommand DownloadDataCommand { get; }
        ICommand StartCommand { get; }
        ICommand AbortCommand { get; }

        bool IsHistoryEnabled { get; set; }
        bool IsDownloadEnabled { get; set; }
        bool IsStartEnabled { get; set; }
        bool IsAbortEnabled { get; set; }
        bool IsEventRunning { get; set; }

        ObservableCollection<Mail> ObservableMailEvents { get; set; }
    }
}
