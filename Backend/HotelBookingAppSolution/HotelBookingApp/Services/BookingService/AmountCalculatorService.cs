using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Interface.IService.IBookingService;
using HotelBookingApp.Models.Bookings;

namespace HotelBookingApp.Services.BookingService
{
    public class AmountCalculatorService : IAmountCalculatorService
    {
        public readonly IRoomTypeRepository _roomTypeRepository;
        public readonly decimal OnlineBooking;
        public readonly decimal OfflineBooking;

        public AmountCalculatorService(IRoomTypeRepository roomTypeRepository)
        {
            OnlineBooking = 0.025m;
            OfflineBooking = 0.05m;
            _roomTypeRepository = roomTypeRepository;
        }

        public Task<(decimal AdvanceAmount, decimal HotelAmount)> AdvanceAndHotelAmountCalculator(decimal totalAmount, EnumBookingTypes enumBookingTypes)
        {
            try
            {
                if (EnumBookingTypes.OnlineBookingWithOnlinePayment == enumBookingTypes)
                {
                    decimal advanceAmount = totalAmount * OnlineBooking;
                    decimal hotelAmount = totalAmount - advanceAmount;
                    return Task.FromResult((advanceAmount, hotelAmount));
                }
                else if (EnumBookingTypes.OnlineBookingWithOfflinePayment == enumBookingTypes)
                {
                    decimal advanceAmount = totalAmount * OfflineBooking;
                    decimal hotelAmount = totalAmount - advanceAmount;
                    return Task.FromResult((advanceAmount, hotelAmount));
                }
                else
                {
                    throw new Exception("Invalid Booking Type");
                }
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException(ex.Message);
            }
        }

        public async Task<decimal> CalculatorTotalRoomCharge(int roomTypeId, int noOfRooms)
        {
            try
            {
                var roomType = await _roomTypeRepository.GetByIdAsync(roomTypeId);
                if (roomType == null)
                {
                    throw new Exception("Room Type not found");
                }

                decimal totalAmount = roomType.RoomPrice * noOfRooms;
                
                return totalAmount;
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException(ex.Message);
            }
        }
    }
}
