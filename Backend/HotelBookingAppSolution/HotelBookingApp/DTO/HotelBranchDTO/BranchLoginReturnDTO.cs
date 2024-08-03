namespace HotelBookingApp.DTO.HotelBranchDTO
{
    public class BranchLoginReturnDTO
    {
        public string? BranchEmail { get; set; }
        public int BranchId { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
