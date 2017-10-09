using System;

namespace KFIsher.Mobile.Services.Connection
{
    public class ErrorEventArgs : EventArgs
    {
        private readonly Exception error;

        private readonly string message;

        public Exception Error => this.error;

        public string Message => this.message;

        /// <summary>
        /// Create a error object, which holds the exception and the error message
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="msg"></param>
        public ErrorEventArgs(Exception ex, string msg)
        {
            this.error = ex;
            this.message = msg;
        }
    }
}
