namespace CheckD.WPF.Commands
{
    public abstract class AsyncCommandBase:CommandBase
    {
        private bool _isExcuting;

        public bool IsExcuting
        {
            get { return _isExcuting; }
            set { _isExcuting = value; }
        }

        public override bool CanExecute(object? parameter)
        {
            return !IsExcuting && base.CanExecute(parameter);
        }
        public override async void Execute(object? parameter)
        {
            IsExcuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception)
            {

            }
            finally
            {
                IsExcuting = false;
            }
        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
