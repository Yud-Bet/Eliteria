using System.Windows.Input;

namespace Eliteria.Command
{
    class ShowMessageCommand : BaseCommand
    {
        private Stores.NavigationStore _homeNavStore;
        private ICommand OpenMessageCommand;
        private string _title;
        private string _message;

        public ShowMessageCommand(Stores.NavigationStore homeNavStore, string title, string message)
        {
            _homeNavStore = homeNavStore;
            _title = title;
            _message = message;
        }

        public override void Execute(object parameter)
        {
            OpenMessageCommand = new NavigateCMD(CreateOpenModalNavSvc());
            OpenMessageCommand?.Execute(null);
        }

        private Services.INavigationService CreateOpenModalNavSvc()
        {
            return new Services.ModalNavigationService<ViewModels.MessageDialogViewModel>(_homeNavStore,
                () => new ViewModels.MessageDialogViewModel(_title, _message, _homeNavStore));
        }
    }
}
