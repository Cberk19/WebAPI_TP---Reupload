using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;

namespace Utilities
{

    public class House
    {
        public int HouseID { get; set; }
        public String Address { get; set; }
        public String PropertyType { get; set; }
        public int HomeSize { get; set; }
        public String CoverImageUrl { get; set; }
        public List<Room> Rooms { get; set; }
        public List<HouseImage> Images { get; set; }
        public int NumberOfBedrooms { get; set; }
        public String Amenities { get; set; }
        public int HouseYear { get; set; }
        public String Garage { get; set; }
        public String Utilities { get; set; }
        public String HomeDescription { get; set; }
        public decimal AskingPrice { get; set; }
        public String HouseImages { get; set; }
        public String State { get; set; }
        public int NumberOfBathrooms { get; set; }
        public String City { get; set; }
        public int SellerID { get; set; }
        public int RealEstateID { get; set; }
        public House()
        {
        }

        public override string ToString()
        {
            return HouseID + " " + Address;
        }
    }

    public class Room
    {
        public String RoomDescription { get; set; }
        public int RoomSizeL { get; set; }
        public int RoomSizeW { get; set; }
    }

    public class Comment
    {
        public String Address { get; set; }
        public String Username { get; set; }
        public String Content { get; set; }
    }

    public class HouseImage
    {
        public string Address { get; set; }
        public String Url { get; set; }
        public String ImageDescription { get; set; }
    }

}