using HotelBookingApp.DTO.BookingDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IBookings;
using HotelBookingApp.Interface.IRepository.IGuests;
using HotelBookingApp.Interface.IRepository.Payments;
using HotelBookingApp.Interface.IService.IBookingService;
using HotelBookingApp.Models.Booking;
using HotelBookingApp.Models.Bookings;
using HotelBookingApp.Models.Payment;

namespace HotelBookingApp.Services.BookingService
{
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IBookingHistoryRepository _bookingHistoryRepository; 
        private readonly IGuestRepository _guestRepository;
        private readonly IAmountCalculatorService _amountCalculatorService;
        private readonly IBookingPaymentRepository _bookingPaymentRepository;
        public HotelBookingService(IBookingHistoryRepository bookingHistoryRepository, IGuestRepository guestRepository, IAmountCalculatorService amountCalculatorService, IBookingPaymentRepository bookingPaymentRepository)
        {
            _bookingHistoryRepository = bookingHistoryRepository;
            _guestRepository = guestRepository;
            _amountCalculatorService = amountCalculatorService;
            _bookingPaymentRepository = bookingPaymentRepository;
        }

        public async Task<HotelBookingDTO> AddNewHotelBooking(BookingBranchDTO bookingBranchDTO)
        {
            if(bookingBranchDTO == null)
            {
                throw new Exception("Booking History and Guest cannot be null");
            }
            try
            {
                var GetGuestBookingHistory = await _bookingHistoryRepository.GetBookingByGuestId(bookingBranchDTO.GuestId);
                var CheckHotelVacancy = await _bookingHistoryRepository.GetBookingByHotelBranchId(bookingBranchDTO.HotelBranchId);
                var AddPayment = new BookingPayment();
                var NewBranchBookingDTO = new BookingHistory()
                {
                    HotelBranchId = bookingBranchDTO.HotelBranchId,
                    GuestId = bookingBranchDTO.GuestId,
                    CheckInDate = bookingBranchDTO.CheckInDate,
                    CheckOutDate = bookingBranchDTO.CheckOutDate,
                    CurrentInOutStatus = EnumCurrentInOutStatus.BookedAndWaitingForCheckIn,
                    BookingPaymentStatus = EnumBookingPaymentStatus.NotPaid,
                    BookingStatus = EnumBookingStatus.RoomsSelected,
                    RoomTypeId = bookingBranchDTO.RoomTypeId,
                    NumberOfRooms = bookingBranchDTO.NumberOfRooms,
                    CheckInTime = bookingBranchDTO.CheckInTime,
                    CheckOutTime = bookingBranchDTO.CheckOutTime,
                    NumberOfAdults = bookingBranchDTO.NumberOfAdults,
                    NumberOfChildren = bookingBranchDTO.NumberOfChildren,
                    TotalAmount = await _amountCalculatorService.CalculatorTotalRoomCharge(bookingBranchDTO.RoomTypeId, bookingBranchDTO.NumberOfRooms),
                    BookingType = bookingBranchDTO.BookingType

                };
                if(GetGuestBookingHistory.Any(x=>x.CurrentInOutStatus != EnumCurrentInOutStatus.CheckedOut))
                {
                    if(GetGuestBookingHistory.Any(x=>x.CheckInDate== bookingBranchDTO.CheckInDate && x.CheckOutDate== bookingBranchDTO.CheckOutDate))
                    {
                        var ConnectingBooking = await AddNewHotelBookingWithConnection(bookingBranchDTO);
                    }

                    
                }
                var AddBooking = await _bookingHistoryRepository.AddNewBookingAsync(NewBranchBookingDTO);
                if (NewBranchBookingDTO.BookingType == EnumBookingTypes.OnlineBookingWithOfflinePayment)
                {
                }
                else if(NewBranchBookingDTO.BookingType == EnumBookingTypes.OnlineBookingWithOnlinePayment)
                {
                    var (advanceAmount, hotelAmount) = await _amountCalculatorService.AdvanceAndHotelAmountCalculator(
                                                        AddBooking.TotalAmount,
                                                        NewBranchBookingDTO.BookingType
        );
                    var PaymentDTO = new BookingPayment()
                    {
                        BookingId = AddBooking.BookingId,
                        TotalAmountForBooking = AddBooking.TotalAmount,
                        AdvanceAmount = advanceAmount,
                        HotelAmount = hotelAmount,
                        AdvancePaymentStatus = Models.Payments.EnumPaymentStatus.Pending,
                        HotelPaymentStatus = Models.Payments.EnumPaymentStatus.Pending,
                        AdvancePaymentMethod = Models.Payments.EnumPaymentMethod.NA,
                        AdvancePaymentTransactionId = null,
                        AdvancePaymentDate = DateTime.MinValue,
                        HotelPaymentMethod = Models.Payments.EnumPaymentMethod.NA,
                        HotelPaymentTransactionId = null,
                        HotelPaymentDate = DateTime.MinValue
                        
                    };
                    PaymentDTO.Booking= AddBooking;
                    AddPayment = await _bookingPaymentRepository.AddBooking(PaymentDTO);
                    if(AddPayment == null)
                    {
                        throw new Exception("Error in connecting to the repository");
                    }
                }
                if (AddBooking == null)
                {
                    throw new Exception("Error in connecting to the repository");
                }
                //var UpdateRoomStatus = await 

                return new HotelBookingDTO
                {                    
                    RoomType= AddBooking.RoomType,
                    BookingHistory = AddBooking,
                    BookingPayment= AddPayment,
                    Hotel= AddBooking.HotelBranch
                };

            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }

        public Task<HotelBookingDTO> AddNewHotelBookingWithConnection(BookingBranchDTO bookingBranchDTO)
        {
            throw new NotImplementedException();
        }

        public Task<HotelBookingDTO> CancelHotelBooking(int hotelBookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelBookingDTO>> GetAllHotelBookingUnderHotel()
        {
            throw new NotImplementedException();
        }

        public Task<HotelBookingDTO> GetHotelBooking(int hotelBookingId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelBookingDTO> UpdateHotelBooking(BookingBranchDTO bookingBranchDTO)
        {
            throw new NotImplementedException();
        }
    }
}
