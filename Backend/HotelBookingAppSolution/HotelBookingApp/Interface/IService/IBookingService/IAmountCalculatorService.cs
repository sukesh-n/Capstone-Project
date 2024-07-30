using HotelBookingApp.Models.Bookings;
using HotelBookingApp.Models.Payments;

namespace HotelBookingApp.Interface.IService.IBookingService
{
    public interface IAmountCalculatorService
    {
        public Task<decimal> CalculatorTotalRoomCharge(int roomTypeId, int noOfRooms);
        public Task<(decimal AdvanceAmount,decimal HotelAmount)> AdvanceAndHotelAmountCalculator(decimal totalAmount,EnumBookingTypes enumBookingTypes);

    }
}
