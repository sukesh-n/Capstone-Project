using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Interface.IRepository.IHotels
{
    public interface IHotelImagesRepository
    {
        public Task<List<HotelImages>> AddHotelImages(List<HotelImages> HotelImagesList);
        public Task<List<HotelImages>> GetHotelImages(int HotelBranchId);
        public Task<bool> DeleteHotelImages(int HotelBranchId);


    }
}
