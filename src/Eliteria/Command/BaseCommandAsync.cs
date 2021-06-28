using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    public abstract class BaseCommandAsync : ICommand
    {
        private bool _isExecuting;

        public event EventHandler CanExecuteChanged;
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        protected void OnCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
