﻿using System.Runtime.Serialization;

namespace HotelBookingApp.Repositories.HotelsRepository.HotelGroupsRepository
{
    [Serializable]
    internal class ErrorInConnectingRepository : Exception
    {
        public ErrorInConnectingRepository()
        {
        }

        public ErrorInConnectingRepository(string? message) : base(message)
        {
        }

        public ErrorInConnectingRepository(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorInConnectingRepository(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}