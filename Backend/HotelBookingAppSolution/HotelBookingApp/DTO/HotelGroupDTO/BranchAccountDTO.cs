﻿using HotelBookingApp.Models.Hotels.HotelBranches;

namespace HotelBookingApp.DTO.HotelGroupDTO
{
    public class BranchAccountDTO
    {
        public HotelBranch? Hotel { get; set; }
        public string Password { get; set; } = string.Empty;

    }
}
