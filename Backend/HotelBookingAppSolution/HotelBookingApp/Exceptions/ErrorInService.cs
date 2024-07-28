using System.Runtime.Serialization;

namespace HotelBookingApp.Exceptions
{
    [Serializable]
    internal class ErrorInService : Exception
    {
        public ErrorInService()
        {
        }

        public ErrorInService(string? message) : base(message)
        {
        }

        public ErrorInService(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorInService(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}