using System;

namespace KFIsher.Mobile.Services.Connection
{
    public class ConnectionEvents
    {
        /// <summary>
        /// Raised whenever a http request fails
        /// </summary>
        public static event EventHandler<ErrorEventArgs> OnErrorEvent = delegate { };
        
        /// <summary>
        /// Invokes event for error occured when HttpResponse throws exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void InvokeErrorEvent(object sender, ErrorEventArgs args)
        {
            OnErrorEvent(sender, args);
        }
    }
}