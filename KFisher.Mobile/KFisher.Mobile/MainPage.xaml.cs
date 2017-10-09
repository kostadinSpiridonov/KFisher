using KFisher.Mobile.ViewModels.User;
using KFIsher.Mobile.Services.Services;
using Xamarin.Forms;

namespace KFisher.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var userService = DependencyLocator.DependencyLocator.GetIntance<IUserService>();
            var vm = new UserProfileViewModel(userService);
        }
    }
}
