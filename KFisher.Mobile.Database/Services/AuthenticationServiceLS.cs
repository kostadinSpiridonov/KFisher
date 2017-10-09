using KFisher.Mobile.Database.Data;

namespace KFisher.Mobile.Database.Services
{
    public class AuthenticationServiceLS : IAuthenticationServiceLS
    {
        /// <summary>
        /// Return the saved api authentication token from the local storage
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetToken()
        {
            return LocalStorage.GetElementValue<string>(LocalStorageKeys.AuthenticationToken);
        }

        /// <summary>
        /// Save passed token into the local storage
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string SaveToken(string token)
        {
            LocalStorage.AddElement(LocalStorageKeys.AuthenticationToken, token);
            return token;
        }
    }
}
