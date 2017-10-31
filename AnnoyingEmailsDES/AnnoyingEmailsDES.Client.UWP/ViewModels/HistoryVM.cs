using AnnoyingEmailsDES.Client.Domain.Repositories;
using AnnoyingEmailsDES.Client.Domain.ViewModels;
using Microsoft.Practices.Prism.Mvvm;
using System;

namespace AnnoyingEmailsDES.Client.UWP.ViewModels
{
    /*
     * HistoryVM for HistoryView. Extends BindableBase (Prism.MVVM framework) and implements IHistoryVM abstraction.
     * This class is responsible for printing the history of all simulations.
     */
    public class HistoryVM : BindableBase, IHistoryVM
    {
        public Action DbErrorAction { get; set; }

        private readonly ISimulationsRepository _simulationsRepository;






        //Constructor - injecting abstractions with StructureMap.
        public HistoryVM(ISimulationsRepository simulationsRepository)
        {
            _simulationsRepository = simulationsRepository;

            _simulationsRepository.DatabaseErrorAction = DbError;
        }









        //Method responsible for showing the database error box.
        private void DbError()
        {
            DbErrorAction();
        }
    }
}
