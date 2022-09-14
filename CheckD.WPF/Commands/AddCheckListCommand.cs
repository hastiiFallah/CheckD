using CheckD.WPF.Stores;
using CheckD.WPF.ViewModel;

namespace CheckD.WPF.Commands
{
    public class AddCheckListCommand : AsyncCommandBase
    {
        private readonly AddCheckListViewModel _addCheckListViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly CheckListStore _checkListStore;

        public AddCheckListCommand(AddCheckListViewModel addCheckListViewModel,
            ModelNavigationStore modelNavigationStore,
            CheckListStore checkListStore)
        {
            _addCheckListViewModel = addCheckListViewModel;
            _modelNavigationStore = modelNavigationStore;
            _checkListStore = checkListStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
