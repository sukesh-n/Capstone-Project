using HotelBookingApp.Context;
using HotelBookingApp.Interface.IRepository.IAdmins;
using HotelBookingApp.Interface.IRepository.IBookings;
using HotelBookingApp.Interface.IRepository.IGuest.IGuests;
using HotelBookingApp.Interface.IRepository.IGuests;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Interface.IRepository.Payments;
using HotelBookingApp.Interface.IService.FreeBrowse;
using HotelBookingApp.Interface.IService.IBookingService;
using HotelBookingApp.Interface.IService.IGuestService;
using HotelBookingApp.Interface.IService.IHotelBranchService;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using HotelBookingApp.Interface.IToken;
using HotelBookingApp.Repositories.AdminsRepository;
using HotelBookingApp.Repositories.BookingsRepository;
using HotelBookingApp.Repositories.GuestsRepository;
using HotelBookingApp.Repositories.HotelsRepository;
using HotelBookingApp.Repositories.HotelsRepository.HotelBranchesRepository;
using HotelBookingApp.Repositories.HotelsRepository.HotelGroupsRepository;
using HotelBookingApp.Repositories.PaymentsRepository;
using HotelBookingApp.Services.BlobService;
using HotelBookingApp.Services.BookingService;
using HotelBookingApp.Services.FreeBrowse;
using HotelBookingApp.Services.GuestService;
using HotelBookingApp.Services.Hashing;
using HotelBookingApp.Services.HotelBranchService;
using HotelBookingApp.Services.HotelGroupService;
using HotelBookingApp.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace HotelBookingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });
            //Debug.WriteLine(builder.Configuration["TokenKey:JWT"]);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"])),
                        RoleClaimType = ClaimTypes.Role
                    };

                });

            #region Database Connection
            builder.Services.AddDbContext<HotelBookingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion
            // Database Connection

            #region Method 
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminSecurityRepository, AdminSecurityRepository>();
            builder.Services.AddScoped<IBookingHistoryRepository, BookingHistoryRepository>();
            builder.Services.AddScoped<ICancellationRepository, CancellationRepository>();
            builder.Services.AddScoped<IGuestDemographicsRepository, GuestDemographicsRepository>();
            builder.Services.AddScoped<IGuestGenuinenessRepository, GuestGenuinenessRepository>();
            builder.Services.AddScoped<IGuestRepository, GuestRepository>();
            builder.Services.AddScoped<IGuestSecurityRepository, GuestSecurityRepository>();
            builder.Services.AddScoped<IHotelBranchRepository, HotelBranchRepository>();
            builder.Services.AddScoped<IHotelBranchSecurityRepository, HotelBranchSecurityRepository>();
            builder.Services.AddScoped<IHotelGroupRepository, HotelGroupRepository>();
            builder.Services.AddScoped<IHotelGroupSecurityRepository, HotelGroupSecurityRepository>();
            builder.Services.AddScoped<IBranchFeedbackRepository, BranchFeedbackRepository>();
            builder.Services.AddScoped<IBranchStatusRepository, BranchStatusRepository>();
            builder.Services.AddScoped<IGroupFeedbackRepository, GroupFeedbackRepository>();
            builder.Services.AddScoped<IHotelAmenitiesRepository, HotelAmenitiesRepository>();
            builder.Services.AddScoped<IHotelBranchRulesRepository, HotelBranchRulesRepository>();
            builder.Services.AddScoped<IHotelDemographicsRepository, HotelDemographicsRepository>();
            builder.Services.AddScoped<IHotelImagesRepository, HotelImagesRepository>();
            builder.Services.AddScoped<IRoomAmenitiesRepository , RoomAmenitiesRepository>();
            builder.Services.AddScoped<IRoomTypeRepository , RoomTypeRepository>();
            builder.Services.AddScoped<IBookingPaymentRepository, BookingPaymentRepository>();
            builder.Services.AddScoped<IHotelSettlementRepository , HotelSettlementRepository>();
            builder.Services.AddScoped<IRefundRepository , RefundRepository>();
            builder.Services.AddScoped<IRevenueRepository , RevenueRepository>();

            #endregion

            #region Service
            builder.Services.AddScoped<Password>();
            builder.Services.AddScoped<IAmountCalculatorService, AmountCalculatorService>();
            builder.Services.AddScoped<IHotelBrowseService, HotelBrowseService>();
            builder.Services.AddScoped<IHotelBookingService, HotelBookingService>();
            builder.Services.AddScoped<IGuestAccountService, GuestAccountService>();
            builder.Services.AddScoped<IGuestLoginService,GuestLoginService>();
            builder.Services.AddScoped<IGuestAccountService, GuestAccountService>();
            builder.Services.AddScoped<IGuestDemographicsService, GuestDemographicsService>();
            builder.Services.AddScoped<IBranchBookingManagementService,BranchBookingService>();
            builder.Services.AddScoped<IBranchLoginService, BranchLoginService>();
            builder.Services.AddScoped<IBranchAccountService,BranchAccountService>();
            builder.Services.AddScoped<IGroupAccountService, GroupAccountService>();
            builder.Services.AddScoped<IGroupLoginService, GroupLoginService>();
            builder.Services.AddScoped<ITokenService,TokenService>();
            builder.Services.AddScoped<IHotelGroupManagementService, HotelGroupManagementService>();
            builder.Services.AddScoped<IHotelManagementService, HotelManagementService>();
            #endregion

            builder.Services.AddScoped<HotelImageBlobService>();
            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("CORSHBA", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CORSHBA");

            app.MapControllers();

            app.Run();
        }
    }
}
