using KFIsher.Mobile.Services.Services;

namespace KFisher.Mobile.ViewModels.User
{
    public class UserProfileViewModel
    {
        private IUserService userService;

        public UserProfileViewModel(IUserService userService)
        {
            this.userService = userService;
        }
    }
}
