using System.Runtime.Serialization;

namespace HotelBookingApp.Exceptions
{
    [Serializable]
    internal class ErrorInServiceException : Exception
    {
        public ErrorInServiceException()
        {
        }

        public ErrorInServiceException(string? message) : base(message)
        {
        }

        public ErrorInServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorInServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}