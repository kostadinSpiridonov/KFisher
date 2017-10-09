namespace KFisher.Mobile.Database.Services
{
    public interface IAuthenticationServiceLS
    {
        /// <summary>
        /// Return the saved api authentication token from the local storage
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        string SaveToken(string token);

        /// <summary>
        /// Save passed token into the local storage
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        string GetToken();
    }
}
