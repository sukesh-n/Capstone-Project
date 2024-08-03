using HotelBookingApp.DTO.HotelBrowseDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IBookings;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches;
using HotelBookingApp.Interface.IService.FreeBrowse;
using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;

namespace HotelBookingApp.Services.FreeBrowse
{
    public class HotelBrowseService : IHotelBrowseService
    {
        public IHotelBranchRepository _hotelBranchRepository;
        public IHotelDemographicsRepository _hotelDemographicsRepository;
        public IRoomTypeRepository _roomTypeRepository;
        public IRoomAmenitiesRepository _roomAmenitiesRepository;
        public IHotelBranchRulesRepository _hotelBranchRulesRepository;
        public IBookingHistoryRepository _bookingHistoryRepository;


        public HotelBrowseService(IHotelBranchRepository hotelBranchRepository, IHotelDemographicsRepository hotelDemographicsRepository, IRoomTypeRepository roomTypeRepository, IRoomAmenitiesRepository roomAmenitiesRepository, IHotelBranchRulesRepository hotelBranchRulesRepository, IBookingHistoryRepository bookingHistoryRepository)
        {
            _hotelBranchRepository = hotelBranchRepository;
            _hotelDemographicsRepository = hotelDemographicsRepository;
            _roomTypeRepository = roomTypeRepository;
            _roomAmenitiesRepository = roomAmenitiesRepository;
            _hotelBranchRulesRepository = hotelBranchRulesRepository;
            _bookingHistoryRepository = bookingHistoryRepository;
        }

        public async Task<IEnumerable<BranchRoomTypeFetchReturnDTO>> BranchRoomTypeFetchReturnDTOs(int BranchId, DateTime CheckInDate, DateTime CheckOutDate)
        {
            try
            {
                var roomTypes = await _roomTypeRepository.GetRoomTypesByBranchId(BranchId);
                if (roomTypes == null)
                {
                    throw new ErrorInServiceException("No Room Types Found");
                }
                var BranchRoomTypeFetchReturnDTOs = new List<BranchRoomTypeFetchReturnDTO>();
                foreach (var roomType in roomTypes)
                {
                    var IsAvailable = await _bookingHistoryRepository.CheckDateAvailabilityForRoomType(CheckInDate, CheckOutDate, BranchId, roomType.RoomTypeId,roomType.NumberOfRooms);
                    if (IsAvailable.NoOfDaysAvailable == 0)
                    {
                        continue;
                    }
                    var BranchRoomTypeFetchReturnDTO = new BranchRoomTypeFetchReturnDTO
                    {
                        BranchId = roomType.HotelBranchId,
                        RoomType = roomType.RoomTypeName,
                        RoomTypeId = roomType.RoomTypeId,
                        PriceDay = roomType.RoomPrice,
                        NumberOfRoomsAvailable = IsAvailable.NoOfRoomsAvailable,
                        IsAvailable = true,

                    };
                    BranchRoomTypeFetchReturnDTOs.Add(BranchRoomTypeFetchReturnDTO);
                }
                return BranchRoomTypeFetchReturnDTOs;
            }
            catch (Exception e)
            {
                throw new ErrorInServiceException("Error in Service", e);
            }
        }

        public async Task<IEnumerable<HotelBrowseReturnDTO>?> FilterHotelByLocationRequest(HotelBrowseRequestDTO hotelBrowseRequestDTO)
        {
            try
            {
                var FilterHotelByLocation = await _hotelDemographicsRepository.GetHotelBranchByLocation(hotelBrowseRequestDTO.State, hotelBrowseRequestDTO.District);
                if(FilterHotelByLocation == null||FilterHotelByLocation.Count() ==0)
                {
                    return null;
                }
                var FilteredHotelBranches = new List<HotelBrowseReturnDTO>();
                foreach (var hotel in FilterHotelByLocation)
                {
                    
                    TimeSpan timeSpan = hotelBrowseRequestDTO.CheckOutDate.Subtract(hotelBrowseRequestDTO.CheckInDate);

                    
                    int NoOfDaysRequired = (int)timeSpan.TotalDays;

                    var CheckDateAvailability = await _bookingHistoryRepository.CheckDateAvailability(hotelBrowseRequestDTO.CheckInDate, hotelBrowseRequestDTO.CheckOutDate, hotel.HotelId);
                    


                    
                    if (CheckDateAvailability.NoOfDaysAvailable!=0)
                    {
                        var HotelBranchDetail = await _hotelBranchRepository.GetByIdAsync(hotel.HotelId);
                        var RoomTypes = await _roomTypeRepository.GetRoomTypesByBranchId(hotel.HotelId);
                        hotel.Hotel=HotelBranchDetail;                        
                        var FilteredHotelBranch = new HotelBrowseReturnDTO
                        {
                            HotelId = hotel.HotelId,
                            HotelBranchName = HotelBranchDetail.HotelBranchName,
                            HotelDemographics = hotel,
                            HotelType = HotelBranchDetail.HotelType,
                            IsAvailable = (NoOfDaysRequired == CheckDateAvailability.NoOfDaysAvailable),
                            StartDate = CheckDateAvailability.LongestWindowStartDate,
                            EndDate = CheckDateAvailability.LongestWindowEndDate

                        };
                        FilteredHotelBranches.Add(FilteredHotelBranch);
                    }


                }
                return FilteredHotelBranches;
                
            }
            catch (Exception e)
            {
                throw new ErrorInServiceException("Error in Service", e);
            }
        }

        public async Task<List<HotelSpecificDetailsReturnDTO>> FilterHotelByRequest(int BranchId)
        {
            try
            {
                var HotelBranchDetail = await _hotelBranchRepository.GetByIdAsync(BranchId);
                var roomTypes = await _roomTypeRepository.GetRoomTypesByBranchId(BranchId);
                var hotelSpecificDetails = new List<HotelSpecificDetailsReturnDTO>();
                if (HotelBranchDetail == null || roomTypes == null)
                {
                    throw new ErrorInServiceException("No Hotel Branch Found");
                }
                var hotelDemographics = await _hotelDemographicsRepository.GetByIdAsync(BranchId);
                foreach (var roomType in roomTypes)
                {
                    var RoomAmenities = await _roomAmenitiesRepository.GetByBranchAndAmenity(BranchId,roomType.RoomTypeId);
                    var HotelBranchRules = await _hotelBranchRulesRepository.GetByIdAsync(BranchId);
                    var HotelSpecificDetail = new HotelSpecificDetailsReturnDTO
                    {
                        HotelBranch = HotelBranchDetail,
                        HotelDemographics = hotelDemographics,
                        RoomType = roomType,
                        RoomAmenities = RoomAmenities,
                        HotelBranchRules = HotelBranchRules
                    };
                    hotelSpecificDetails.Add(HotelSpecificDetail);
                }
                return hotelSpecificDetails;
                
            }
            catch (Exception e)
            {
                throw new ErrorInServiceException("Error in Service", e);
            }
        }
    }
}
