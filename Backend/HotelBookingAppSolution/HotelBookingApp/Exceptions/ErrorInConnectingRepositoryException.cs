using System.Runtime.Serialization;

namespace HotelBookingApp.Exceptions
{
    [Serializable]
    internal class ErrorInConnectingRepositoryException : Exception
    {
        public ErrorInConnectingRepositoryException()
        {
        }

        public ErrorInConnectingRepositoryException(string? message) : base(message)
        {
        }

        public ErrorInConnectingRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorInConnectingRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}