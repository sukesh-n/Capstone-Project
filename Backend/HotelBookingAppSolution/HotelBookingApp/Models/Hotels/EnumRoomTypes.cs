using System;
using System.Collections.Generic;

namespace HotelBookingApp.Models.Hotels
{
    public enum EnumRoomTypes
    {
        Single,
        Double,
        Triple,
        Quad,
        Queen,
        King,
        Twin,
        DoubleDouble,
        Studio,
        MasterSuite,
        MiniSuite,
        JuniorSuite,
        ExecutiveSuite,
        PresidentialSuite
    }

    public static class RoomTypeDetails
    {
        private static readonly Dictionary<EnumRoomTypes, string> _roomTypeDescriptions = new()
        {
            { EnumRoomTypes.Single, "A single room is a small room designed for one person, usually with a single bed." },
            { EnumRoomTypes.Double, "A double room features a double bed, typically accommodating two people." },
            { EnumRoomTypes.Triple, "A triple room is designed for three people, often featuring either three beds or a combination of a double and a single bed." },
            { EnumRoomTypes.Quad, "A quad room accommodates four people, usually with either two double beds or a combination of beds." },
            { EnumRoomTypes.Queen, "A queen room has a queen-sized bed, suitable for two people who prefer a larger bed." },
            { EnumRoomTypes.King, "A king room features a king-sized bed, offering more space and comfort for two people." },
            { EnumRoomTypes.Twin, "A twin room has two single beds, ideal for two people who prefer separate beds." },
            { EnumRoomTypes.DoubleDouble, "A double-double room includes two double beds, accommodating up to four people comfortably." },
            { EnumRoomTypes.Studio, "A studio room is an open-plan space with a combined living and sleeping area, often including a kitchenette." },
            { EnumRoomTypes.MasterSuite, "A master suite is a luxurious suite featuring a separate bedroom and living area, often with high-end amenities." },
            { EnumRoomTypes.MiniSuite, "A mini suite is a smaller suite offering some of the amenities of a full suite, such as a separate sitting area." },
            { EnumRoomTypes.JuniorSuite, "A junior suite features a larger living space and a separate bedroom area, offering more comfort and privacy." },
            { EnumRoomTypes.ExecutiveSuite, "An executive suite provides additional space and amenities tailored for business travelers, including a separate office area." },
            { EnumRoomTypes.PresidentialSuite, "A presidential suite is the most luxurious room available, featuring expansive space, high-end furnishings, and exclusive amenities." }
        };

        public static string GetDescription(EnumRoomTypes roomType)
        {
            return _roomTypeDescriptions.TryGetValue(roomType, out var description) ? description : "Description not available.";
        }
    }
}