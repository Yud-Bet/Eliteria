namespace Eliteria.Command
{
    class ModalNavigateCMD : BaseCommand
    {
        private readonly Services.INavigationService navigationService;

        public ModalNavigateCMD(Services.INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
