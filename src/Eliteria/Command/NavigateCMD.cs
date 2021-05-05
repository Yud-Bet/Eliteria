using System;

namespace Eliteria.Command
{
    class NavigateCMD<T> : BaseCommand
        where T : ViewModels.BaseViewModel
    {
        private readonly Services.NavigationService<T> navigationService;

        public NavigateCMD(Services.NavigationService<T> navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
