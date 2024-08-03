using HotelBookingApp.Models.Admins;
using HotelBookingApp.Models.Booking;
using HotelBookingApp.Models.Bookings;
using HotelBookingApp.Models.Guests;
using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Models.Hotels.HotelGroups;
using HotelBookingApp.Models.Payment;
using HotelBookingApp.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Context
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<AdminSecurity> AdminSecurities { get; set; } = null!;
        public DbSet<BookingHistory> BookingHistories { get; set; } = null!;
        public DbSet<Cancellation> Cancellations { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;
        public DbSet<GuestDemographics> GuestDemographics { get; set; } = null!;
        public DbSet<GuestGenuineness> GuestGenuinenesses { get; set; } = null!;
        public DbSet<GuestSecurity> GuestSecurities { get; set; } = null!;
        public DbSet<HotelBranch> HotelBranches { get; set; } = null!;
        public DbSet<HotelBranchSecurity> HotelBranchSecurities { get; set; } = null!;
        public DbSet<HotelGroup> HotelGroups { get; set; } = null!;
        public DbSet<HotelGroupSecurity> HotelGroupSecurities { get; set; } = null!;
        public DbSet<BranchFeedback> BranchFeedbacks { get; set; } = null!;
        public DbSet<BranchStatus> BranchStatuses { get; set; } = null!;
        public DbSet<GroupFeedback> GroupFeedbacks { get; set; } = null!;
        public DbSet<HotelAmenities> HotelAmenities { get; set; } = null!;
        public DbSet<HotelBranchRules> HotelBranchRules { get; set; } = null!;
        public DbSet<HotelDemographics> HotelDemographics { get; set; } = null!;
        public DbSet<HotelImages> HotelImages { get; set; } = null!;
        public DbSet<RoomAmenities> RoomAmenities { get; set; } = null!;
        public DbSet<RoomType> RoomTypes { get; set; } = null!;
        public DbSet<BookingPayment> BookingPayments { get; set; } = null!;
        public DbSet<HotelSettlement> HotelSettlements { get; set; } = null!;
        public DbSet<HotelSettlementPayment> HotelSettlementPayments { get; set; } = null!;
        public DbSet<Refund> Refunds { get; set; } = null!;
        public DbSet<Revenue> Revenues { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<RoomAmenities>()
                .HasKey(r => new { r.HotelBranchId, r.RoomTypeId });

            // Configure other entity mappings and relationships as needed
            modelBuilder.Entity<RoomAmenities>()
                .HasOne(r => r.Hotel)
                .WithMany()  // You may need to specify the inverse navigation property if there is one
                .HasForeignKey(r => r.HotelBranchId);

            modelBuilder.Entity<RoomAmenities>()
                .HasOne(r => r.RoomType)
                .WithMany()  // You may need to specify the inverse navigation property if there is one
                .HasForeignKey(r => r.RoomTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
