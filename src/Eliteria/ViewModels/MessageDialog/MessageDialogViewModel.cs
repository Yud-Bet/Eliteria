using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class MessageDialogViewModel: BaseViewModel
    {
        private string _title;
        private string _content;

        public MessageDialogViewModel(string title, string content, Stores.NavigationStore navigationStore)
        {
            _title = title;
            _content = content;
            CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(navigationStore));
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertychanged(Title);
            }
        }
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertychanged(Content);
            }
        }

        public ICommand CloseCMD { get; }
    }
}
