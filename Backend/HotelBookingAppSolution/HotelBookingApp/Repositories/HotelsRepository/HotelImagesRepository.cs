using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class HotelImagesRepository : IHotelImagesRepository
    {
        public Task<List<HotelImages>> AddHotelImages(List<HotelImages> HotelImagesList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHotelImages(int HotelBranchId)
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelImages>> GetHotelImages(int HotelBranchId)
        {
            throw new NotImplementedException();
        }
    }
}
