using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Class For Custom Exception Type Handling
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CabInVoiceException : Exception
    {
        /// <summary>
        /// Enum For Exception Type
        /// </summary>
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVLAID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInVoiceException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public CabInVoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}