using CheckD.WPF.ViewModel;

namespace CheckD.WPF.Stores
{
    public class ModelNavigationStore
    {
        private  BaseViewModel _currentViewModel;
        public bool isOpen=> CurrentViewModel != null;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        internal void Close()
        {
            CurrentViewModel = null;
        }
        public event Action CurrentViewModelChanged;
    }
}
