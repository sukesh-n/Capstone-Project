using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastlogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastlogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "HotelGroups",
                columns: table => new
                {
                    HotelGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelGroupManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelGroupEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelGroupPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelGroups", x => x.HotelGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AdminSecurities",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    AdminPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AdminPasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSecurities", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_AdminSecurities_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestDemographics",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    DoorNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestDemographics", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_GuestDemographics_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestGenuinenesses",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    ContinuousCancellationCount = table.Column<int>(type: "int", nullable: false),
                    TotalCancellationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestGenuinenesses", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_GuestGenuinenesses_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestSecurities",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    GuestPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GuestPasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestSecurities", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_GuestSecurities_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFeedbacks",
                columns: table => new
                {
                    GroupFeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelGroupId = table.Column<int>(type: "int", nullable: false),
                    TotalRating = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFeedbacks", x => x.GroupFeedbackId);
                    table.ForeignKey(
                        name: "FK_GroupFeedbacks_HotelGroups_HotelGroupId",
                        column: x => x.HotelGroupId,
                        principalTable: "HotelGroups",
                        principalColumn: "HotelGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelBranches",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelGroupId = table.Column<int>(type: "int", nullable: false),
                    HotelBranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelType = table.Column<int>(type: "int", nullable: false),
                    HotelBranchManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelBranchEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelBranchPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranches", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_HotelBranches_HotelGroups_HotelGroupId",
                        column: x => x.HotelGroupId,
                        principalTable: "HotelGroups",
                        principalColumn: "HotelGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelGroupSecurities",
                columns: table => new
                {
                    HotelGroupId = table.Column<int>(type: "int", nullable: false),
                    HotelGroupPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HotelGroupPasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelGroupSecurities", x => x.HotelGroupId);
                    table.ForeignKey(
                        name: "FK_HotelGroupSecurities_HotelGroups_HotelGroupId",
                        column: x => x.HotelGroupId,
                        principalTable: "HotelGroups",
                        principalColumn: "HotelGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchFeedbacks",
                columns: table => new
                {
                    BranchFeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    TotalRating = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchFeedbacks", x => x.BranchFeedbackId);
                    table.ForeignKey(
                        name: "FK_BranchFeedbacks_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchStatuses",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    AvailableRooms = table.Column<int>(type: "int", nullable: false),
                    BookedRooms = table.Column<int>(type: "int", nullable: false),
                    PlannedClosureFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedClosureTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStatuses", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_BranchStatuses_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelAmenities",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasFreePickup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenities", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_HotelAmenities_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelBranchRules",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CanCheckInEarly = table.Column<bool>(type: "bit", nullable: false),
                    CanCheckOutLate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranchRules", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_HotelBranchRules_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelBranchSecurities",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    HotelBranchPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HotelBranchPasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranchSecurities", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_HotelBranchSecurities_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelDemographics",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapCoordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NearestAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceFromAirport = table.Column<float>(type: "real", nullable: false),
                    NearestRailwayStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceFromRailwayStation = table.Column<float>(type: "real", nullable: false),
                    NearestBusStand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceFromBusStand = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDemographics", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_HotelDemographics_HotelBranches_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    TotalCommissionReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PendingFeeForCurrentMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PendingFeeForNextMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_Revenues_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeName = table.Column<int>(type: "int", nullable: false),
                    RoomTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    RoomPrice = table.Column<float>(type: "real", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfBed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
                    table.ForeignKey(
                        name: "FK_RoomTypes_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHistories",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingType = table.Column<int>(type: "int", nullable: false),
                    BookingPaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CurrentInOutStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHistories", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingHistories_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookingHistories_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookingHistories_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_HotelImages_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HotelImages_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    IsOnGroundFloor = table.Column<bool>(type: "bit", nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false),
                    HasTelevision = table.Column<bool>(type: "bit", nullable: false),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    HasRefrigerator = table.Column<bool>(type: "bit", nullable: false),
                    HasTelephone = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachedBathroom = table.Column<bool>(type: "bit", nullable: false),
                    HasRoomService = table.Column<bool>(type: "bit", nullable: false),
                    HasLaundryService = table.Column<bool>(type: "bit", nullable: false),
                    HasDoorStepDeliveryService = table.Column<bool>(type: "bit", nullable: false),
                    IsWithBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    IsWindowAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsBalconyAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsBeachViewAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => x.HotelBranchId);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BookingPayments",
                columns: table => new
                {
                    BookingPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    TotalAmountForBooking = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotelAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdvancePaymentStatus = table.Column<int>(type: "int", nullable: false),
                    HotelPaymentStatus = table.Column<int>(type: "int", nullable: false),
                    AdvancePaymentMethod = table.Column<int>(type: "int", nullable: false),
                    AdvancePaymentTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvancePaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotelPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    HotelPaymentTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPayments", x => x.BookingPaymentId);
                    table.ForeignKey(
                        name: "FK_BookingPayments_BookingHistories_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingHistories",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancellations",
                columns: table => new
                {
                    CancellationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefundAmount = table.Column<float>(type: "real", nullable: false),
                    CnacellationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefundStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellations", x => x.CancellationId);
                    table.ForeignKey(
                        name: "FK_Cancellations_BookingHistories_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingHistories",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelSettlements",
                columns: table => new
                {
                    HotelSettlementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelGroupId = table.Column<int>(type: "int", nullable: false),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    TotalAmountReceivedFromBooking = table.Column<float>(type: "real", nullable: false),
                    AmountToBePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSettlements", x => x.HotelSettlementId);
                    table.ForeignKey(
                        name: "FK_HotelSettlements_BookingHistories_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingHistories",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HotelSettlements_HotelBranches_HotelBranchId",
                        column: x => x.HotelBranchId,
                        principalTable: "HotelBranches",
                        principalColumn: "HotelBranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HotelSettlements_HotelGroups_HotelGroupId",
                        column: x => x.HotelGroupId,
                        principalTable: "HotelGroups",
                        principalColumn: "HotelGroupId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    RefundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingPaymentId = table.Column<int>(type: "int", nullable: false),
                    IsRefundOnCancellation = table.Column<bool>(type: "bit", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefundMethod = table.Column<int>(type: "int", nullable: false),
                    RefundStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.RefundId);
                    table.ForeignKey(
                        name: "FK_Refunds_BookingPayments_BookingPaymentId",
                        column: x => x.BookingPaymentId,
                        principalTable: "BookingPayments",
                        principalColumn: "BookingPaymentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelSettlementPayments",
                columns: table => new
                {
                    HotelSettlementPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelSettlementId = table.Column<int>(type: "int", nullable: false),
                    SettlementPaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SettlementPaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSettlementPayments", x => x.HotelSettlementPaymentId);
                    table.ForeignKey(
                        name: "FK_HotelSettlementPayments_HotelSettlements_HotelSettlementId",
                        column: x => x.HotelSettlementId,
                        principalTable: "HotelSettlements",
                        principalColumn: "HotelSettlementId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_GuestId",
                table: "BookingHistories",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_HotelBranchId",
                table: "BookingHistories",
                column: "HotelBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_RoomTypeId",
                table: "BookingHistories",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPayments_BookingId",
                table: "BookingPayments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFeedbacks_HotelBranchId",
                table: "BranchFeedbacks",
                column: "HotelBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_BookingId",
                table: "Cancellations",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFeedbacks_HotelGroupId",
                table: "GroupFeedbacks",
                column: "HotelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBranches_HotelGroupId",
                table: "HotelBranches",
                column: "HotelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_RoomTypeId",
                table: "HotelImages",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSettlementPayments_HotelSettlementId",
                table: "HotelSettlementPayments",
                column: "HotelSettlementId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSettlements_BookingId",
                table: "HotelSettlements",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSettlements_HotelBranchId",
                table: "HotelSettlements",
                column: "HotelBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSettlements_HotelGroupId",
                table: "HotelSettlements",
                column: "HotelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_BookingPaymentId",
                table: "Refunds",
                column: "BookingPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomTypeId",
                table: "RoomAmenities",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_HotelBranchId",
                table: "RoomTypes",
                column: "HotelBranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSecurities");

            migrationBuilder.DropTable(
                name: "BranchFeedbacks");

            migrationBuilder.DropTable(
                name: "BranchStatuses");

            migrationBuilder.DropTable(
                name: "Cancellations");

            migrationBuilder.DropTable(
                name: "GroupFeedbacks");

            migrationBuilder.DropTable(
                name: "GuestDemographics");

            migrationBuilder.DropTable(
                name: "GuestGenuinenesses");

            migrationBuilder.DropTable(
                name: "GuestSecurities");

            migrationBuilder.DropTable(
                name: "HotelAmenities");

            migrationBuilder.DropTable(
                name: "HotelBranchRules");

            migrationBuilder.DropTable(
                name: "HotelBranchSecurities");

            migrationBuilder.DropTable(
                name: "HotelDemographics");

            migrationBuilder.DropTable(
                name: "HotelGroupSecurities");

            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropTable(
                name: "HotelSettlementPayments");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "HotelSettlements");

            migrationBuilder.DropTable(
                name: "BookingPayments");

            migrationBuilder.DropTable(
                name: "BookingHistories");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "HotelBranches");

            migrationBuilder.DropTable(
                name: "HotelGroups");
        }
    }
}
