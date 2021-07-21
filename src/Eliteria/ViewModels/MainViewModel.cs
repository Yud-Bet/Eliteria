using System;
using System.Data.SqlClient;
using System.Windows;

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public async void AutomaticCalculateInterest()
        {
            try
            {
                await DataAccess.TransactionData.AutomaticCalculateInterest();
            }
            catch (SqlException)
            {
                Command.ShowMessageCommand message = new Command.ShowMessageCommand(this.navigationStore, "Thông báo", "Tự động tính lãi suất thất bại!\nĐã xảy ra lỗi khi cố gắng thiết lập kết nối tới server.\nServer không tồn tại hoặc không có quyền truy cập đến server. Vui lòng kiểm tra lại chuỗi kết nối và chắc chắn rằng server đang hoạt động.");
                message.Execute(null);
            }
            catch (Exception ex)
            {
                Command.ShowMessageCommand message = new Command.ShowMessageCommand(this.navigationStore, "Thông báo", "Tự động tính lãi suất thất bại!\n" + ex.Message);
                message.Execute(null);
            }
        }
        public MainViewModel()
        {
            AutomaticCalculateInterest();
            mainNavigationStore.CurrentViewModel = new LoginViewModel(mainNavigationStore, navigationStore, accountStore);
            mainNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            navigationStore.CurrentModal = null;
            navigationStore.CurrentModalChanged += OnCurrentModalChanged;
        }

        private Stores.NavigationStore mainNavigationStore = new Stores.NavigationStore();
        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        /// <summary>
        /// This store staff account information
        /// </summary>
        private Stores.AccountStore accountStore = new Stores.AccountStore();

        public BaseViewModel CurrentViewModel => mainNavigationStore.CurrentViewModel;
        public BaseViewModel CurrentModal => navigationStore.CurrentModal;
        public bool IsOpen => navigationStore.IsOpen;

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
        private void OnCurrentModalChanged()
        {
            OnPropertychanged(nameof(CurrentModal));
            OnPropertychanged(nameof(IsOpen));
        }
    }
}
