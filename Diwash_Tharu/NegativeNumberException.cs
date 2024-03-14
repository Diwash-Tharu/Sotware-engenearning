using System;
using System.Runtime.Serialization;

namespace Diwash_Tharu
{
    /// <summary>
    /// Represents an exception that is thrown when a negative number is encountered.
    /// </summary>
    [Serializable]
    internal class NegativeNumberException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class with a specified error message.
        /// </summary>
        public NegativeNumberException(string message) : base(message)
        {
        }
    }
}