using Xamarin.Forms;

namespace KFisher.Mobile.Database.Data
{
    public class LocalStorage
    {
        /// <summary>
        /// Add element into the local storage
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddElement(string key, object value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        /// <summary>
        /// Get element from the local storage by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetElementValue<T>(string key) where T : class
        {
            if (ExistElement(key))
            {
                return (Application.Current.Properties[key] as T);
            }

            return default(T);
        }

        /// <summary>
        /// Check whether exists a element in the local storage by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ExistElement(string key)
        {
            return Application.Current.Properties.ContainsKey(key);
        }

        /// <summary>
        /// Remove element from the local storage by key
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveElement(string key)
        {
            if (ExistElement(key))
            {
                Application.Current.Properties.Remove(key);
                Application.Current.SavePropertiesAsync();
            }
        }

        /// <summary>
        /// Remove all elements from the local storage
        /// </summary>
        public static void RemoveAll()
        {
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
        }
    }
}
