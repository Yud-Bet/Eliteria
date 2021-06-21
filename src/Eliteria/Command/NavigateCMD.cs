using System;

namespace Eliteria.Command
{
    class NavigateCMD : BaseCommand
    {
        private readonly Services.INavigationService navigationService;

        public NavigateCMD(Services.INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
