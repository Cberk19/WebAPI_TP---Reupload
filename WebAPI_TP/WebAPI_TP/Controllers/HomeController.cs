using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System;

using System.Data;              // import needed for DataSet and other data classes
using System.Data.SqlClient;    // import needed for ADO.NET classes
using Utilities;                // import needed for DBConnect class
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Routing;
using System.IO;
using Microsoft.Extensions.FileProviders.Physical;
using System.Net;
using System.Security.Policy;
using Microsoft.SqlServer.Server;
using System.Drawing;

namespace WebAPI_TP.Controllers
{

    //AUTO-ADDED:
    //[Produces("application/json")]

    //[Route("api/Teams")]
    [Route("api/houses")]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        // GET api/teams
        [HttpGet]
        public List<House> Get()
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetAllHouses";

            DataSet ds = objDB.GetDataSet(SQLcmd);

            //test();

            List<House> houses = new List<House>();
            House house;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                houses.Add(createHouseObj(record));
            }
            return houses;
        }

        [HttpGet("SellerId/{SellerId}")]
        public List<House> GetHouseBySellerId(int sellerId)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetHousesBySellerId";

            SqlParameter inputSellerId = new SqlParameter("@sellerId", sellerId);

            inputSellerId.SqlDbType = SqlDbType.Int;

            inputSellerId.Size = 500;

            SQLcmd.Parameters.Add(inputSellerId);

            DataSet ds = objDB.GetDataSet(SQLcmd);

            List<House> houses = new List<House>();
            House house;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                houses.Add(createHouseObj(record));
            }
            return houses;
        }
        // GET api/teams/2018
        [HttpGet("{id}")]
        public House Get(int id)
        {
            try
            {
                SqlCommand SQLcmd = new SqlCommand();
                DBConnect objDB = new DBConnect();

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_GetHouseById";

                SqlParameter inputID = new SqlParameter("@id", id);

                inputID.SqlDbType = SqlDbType.Int;

                inputID.Size = 500;

                SQLcmd.Parameters.Add(inputID);

                DataSet ds = objDB.GetDataSet(SQLcmd);

                List<House> houses = new List<House>();
                DataRow record = ds.Tables[0].Rows[0];

                House house = createHouseObj(record);
                return house;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("State/{state}/MinPrice/{minPrice}/MaxPrice/{maxPrice}/PropertyType/{propType}")]
        public List<House> GetHouseStatePricePropertyType(String state, float minPrice, float maxPrice, String propType)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetHouseStatePricePropertyType";

            SqlParameter inputState = new SqlParameter("@theState", state);
            SqlParameter inputMinPrice = new SqlParameter("@theMinPrice", minPrice);
            SqlParameter inputMaxPrice = new SqlParameter("@theMaxPrice", maxPrice);
            SqlParameter inputPropertyType = new SqlParameter("@thePropertyType", propType);

            inputState.SqlDbType = SqlDbType.VarChar;
            inputMinPrice.SqlDbType = SqlDbType.Float;
            inputMaxPrice.SqlDbType = SqlDbType.Float;
            inputPropertyType.SqlDbType = SqlDbType.VarChar;

            inputState.Size = 500;
            inputMinPrice.Size = 500;
            inputMaxPrice.Size = 500;
            inputPropertyType.Size = 500;

            SQLcmd.Parameters.Add(inputState);
            SQLcmd.Parameters.Add(inputMinPrice);
            SQLcmd.Parameters.Add(inputMaxPrice);
            SQLcmd.Parameters.Add(inputPropertyType);

            DataSet ds = objDB.GetDataSet(SQLcmd);

            List<House> houses = new List<House>();
            House house;

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                houses.Add(createHouseObj(record));
            }
            return houses;
        }

        [HttpGet("City/{city}/MinPrice/{minPrice}/MaxPrice/{maxPrice}")]
        public List<House> GetHouseCityPrice(String city, float minPrice, float maxPrice)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetHouseCityPrice";

            SqlParameter inputCity = new SqlParameter("@theCity", city);
            SqlParameter inputMinPrice = new SqlParameter("@theMinPrice", minPrice);
            SqlParameter inputMaxPrice = new SqlParameter("@theMaxPrice", maxPrice);

            inputCity.SqlDbType = SqlDbType.VarChar;
            inputMinPrice.SqlDbType = SqlDbType.Float;
            inputMaxPrice.SqlDbType = SqlDbType.Float;

            inputCity.Size = 500;
            inputMinPrice.Size = 500;
            inputMaxPrice.Size = 500;

            SQLcmd.Parameters.Add(inputCity);
            SQLcmd.Parameters.Add(inputMinPrice);
            SQLcmd.Parameters.Add(inputMaxPrice);

            DataSet ds = objDB.GetDataSet(SQLcmd);

            List<House> houses = new List<House>();
            House house;

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                houses.Add(createHouseObj(record));
            }
            return houses;
        }

        [HttpGet("State/{state}/MinPrice/{minPrice}/MaxPrice/{maxPrice}/NumOfBed/{numOfBed}")]
        public List<House> GetHouseStatePriceNumOfBed(String state, float minPrice, float maxPrice, int numOfBed)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetHouseStatePriceNumOfBed";

            SqlParameter inputState = new SqlParameter("@theState", state);
            SqlParameter inputMinPrice = new SqlParameter("@theMinPrice", minPrice);
            SqlParameter inputMaxPrice = new SqlParameter("@theMaxPrice", maxPrice);
            SqlParameter inputNumOfBed = new SqlParameter("@numOfBed", numOfBed);

            inputState.SqlDbType = SqlDbType.VarChar;
            inputMinPrice.SqlDbType = SqlDbType.Float;
            inputMaxPrice.SqlDbType = SqlDbType.Float;
            inputNumOfBed.SqlDbType = SqlDbType.Int;

            inputState.Size = 500;
            inputMinPrice.Size = 500;
            inputMaxPrice.Size = 500;
            inputNumOfBed.Size = 500;

            SQLcmd.Parameters.Add(inputState);
            SQLcmd.Parameters.Add(inputMinPrice);
            SQLcmd.Parameters.Add(inputMaxPrice);
            SQLcmd.Parameters.Add(inputNumOfBed);

            DataSet ds = objDB.GetDataSet(SQLcmd);

            List<House> houses = new List<House>();
            House house;

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                houses.Add(createHouseObj(record));
            }
            return houses;
        }

        [HttpGet("MinPrice/{minPrice}/MaxPrice/{maxPrice}/NumOfBath/{numOfBath}")]
        public List<House> GetHousePriceNumOfBath(float minPrice, float maxPrice, int numOfBath)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetHousePriceNumOfBath";

            SqlParameter inputMinPrice = new SqlParameter("@theMinPrice", minPrice);
            SqlParameter inputMaxPrice = new SqlParameter("@theMaxPrice", maxPrice);
            SqlParameter inputNumOfBath = new SqlParameter("@numOfBath", numOfBath);

            inputMinPrice.SqlDbType = SqlDbType.Float;
            inputMaxPrice.SqlDbType = SqlDbType.Float;
            inputNumOfBath.SqlDbType = SqlDbType.Int;

            inputMinPrice.Size = 500;
            inputMaxPrice.Size = 500;
            inputNumOfBath.Size = 500;

            SQLcmd.Parameters.Add(inputMinPrice);
            SQLcmd.Parameters.Add(inputMaxPrice);
            SQLcmd.Parameters.Add(inputNumOfBath);

            DataSet ds = objDB.GetDataSet(SQLcmd);

            List<House> houses = new List<House>();
            House house;

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                houses.Add(createHouseObj(record));
            }
            return houses;
        }
        // POST api/teams
        // The [FromBody] attribute is needed in order to pass a JSON object
        // and allow the model-binding to occur properly. This tells the .NET framework
        // to use the 'content-type' header information from the HTTP Request to
        // determine which of the configured IInputFormatters to use in the model-binding.
        [HttpPost]
        public Boolean Post([FromBody] House house)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                String address = house.Address;
                String propertyType = house.PropertyType;
                int numberOfBedrooms = house.NumberOfBedrooms;
                String amenities = house.Amenities;
                int houseYear = house.HouseYear;
                int homeSize = GetTotalSize(house);
                String garage = house.Garage;
                String utilities = house.Utilities;
                String homeDescription = house.HomeDescription;
                float askingPrice = float.Parse(house.AskingPrice.ToString());
                String houseImages = house.HouseImages;
                int numberOfBathrooms = house.NumberOfBathrooms;
                String state = house.State;
                String city = house.City;
                int sellerID = house.SellerID;
                int realEstateID = house.RealEstateID;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_AddHouse";

                SqlParameter inputAddress = new SqlParameter("@theAddress", address);
                SqlParameter inputAmenities = new SqlParameter("@theAmentities", amenities);
                SqlParameter inputState = new SqlParameter("@theState", state);
                SqlParameter inputPrice = new SqlParameter("@thePrice", askingPrice);
                SqlParameter inputCity = new SqlParameter("@theCity", city);
                SqlParameter inputGarage = new SqlParameter("@theGarage", garage);
                SqlParameter inputDescription = new SqlParameter("@theHomeDescription", homeDescription);
                SqlParameter inputSize = new SqlParameter("@theHomeSize", homeSize);
                SqlParameter inputImages = new SqlParameter("@theHouseImages", houseImages);
                SqlParameter inputHouseYear = new SqlParameter("@theHouseYear", houseYear);
                SqlParameter inputNumOfBathrooms = new SqlParameter("@theNumOfBathroom", numberOfBathrooms);
                SqlParameter inputNumOfBedrooms = new SqlParameter("@theNumOfBedrooms", numberOfBedrooms);
                SqlParameter inputPropertyType = new SqlParameter("@thePropertyType", propertyType);
                SqlParameter inputUtilities = new SqlParameter("@theUtilities", utilities);
                SqlParameter inputSellerId = new SqlParameter("@theSellerId", sellerID);
                SqlParameter inputRealEstateId = new SqlParameter("@theRealEstateId", realEstateID);

                inputAddress.SqlDbType = SqlDbType.VarChar;
                inputAmenities.SqlDbType = SqlDbType.VarChar;
                inputState.SqlDbType = SqlDbType.VarChar;
                inputPrice.SqlDbType = SqlDbType.Float;
                inputCity.SqlDbType = SqlDbType.VarChar;
                inputGarage.SqlDbType = SqlDbType.VarChar;
                inputDescription.SqlDbType = SqlDbType.VarChar;
                inputSize.SqlDbType = SqlDbType.Float;
                inputImages.SqlDbType = SqlDbType.VarChar;
                inputHouseYear.SqlDbType = SqlDbType.Int;
                inputNumOfBathrooms.SqlDbType = SqlDbType.Int;
                inputNumOfBedrooms.SqlDbType = SqlDbType.Int;
                inputPropertyType.SqlDbType = SqlDbType.VarChar;
                inputUtilities.SqlDbType = SqlDbType.VarChar;
                inputSellerId.SqlDbType = SqlDbType.Int;
                inputRealEstateId.SqlDbType = SqlDbType.Int;

                inputAddress.Size = 500;
                inputAmenities.Size = 500;
                inputState.Size = 500;
                inputPrice.Size = 500;
                inputCity.Size = 500;
                inputGarage.Size = 500;
                inputDescription.Size = 500;
                inputSize.Size = 500;
                inputImages.Size = 500;
                inputHouseYear.Size = 500;
                inputNumOfBathrooms.Size = 500;
                inputNumOfBedrooms.Size = 500;
                inputPropertyType.Size = 500;
                inputUtilities.Size = 500;
                inputSellerId.Size = int.MaxValue;
                inputRealEstateId.Size = int.MaxValue;


                SQLcmd.Parameters.Add(inputAddress);
                SQLcmd.Parameters.Add(inputAmenities);
                SQLcmd.Parameters.Add(inputState);
                SQLcmd.Parameters.Add(inputPrice);
                SQLcmd.Parameters.Add(inputCity);
                SQLcmd.Parameters.Add(inputGarage);
                SQLcmd.Parameters.Add(inputDescription);
                SQLcmd.Parameters.Add(inputSize);
                SQLcmd.Parameters.Add(inputImages);
                SQLcmd.Parameters.Add(inputHouseYear);
                SQLcmd.Parameters.Add(inputNumOfBathrooms);
                SQLcmd.Parameters.Add(inputNumOfBedrooms);
                SQLcmd.Parameters.Add(inputPropertyType);
                SQLcmd.Parameters.Add(inputUtilities);
                SQLcmd.Parameters.Add(inputSellerId);
                SQLcmd.Parameters.Add(inputRealEstateId);

                rowsAffected = objDB.DoUpdate(SQLcmd);

                PutRooms(house);

                if (rowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex) { return false; }
        }

        [HttpPost("PostComment")]
        public Boolean PostComment([FromBody] Comment comment)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                String address = comment.Address;
                String username = comment.Username;
                String content = comment.Content;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_CreateComment";

                SqlParameter inputAddress = new SqlParameter("@address", address);
                SqlParameter inputUsername = new SqlParameter("@username", username);
                SqlParameter inputComment = new SqlParameter("@comment", content);

                inputAddress.SqlDbType = SqlDbType.VarChar;
                inputUsername.SqlDbType = SqlDbType.VarChar;
                inputComment.SqlDbType = SqlDbType.VarChar;

                inputAddress.Size = 50;
                inputUsername.Size = 50;
                inputComment.Size = 500;


                SQLcmd.Parameters.Add(inputAddress);
                SQLcmd.Parameters.Add(inputUsername);
                SQLcmd.Parameters.Add(inputComment);

                rowsAffected = objDB.DoUpdate(SQLcmd);

                if (rowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex) { return false; }
        }

        [HttpPost("PostImage")]
        public Boolean PostImage([FromBody] HouseImage image)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                String address = image.Address;
                String url = image.Url;
                String desc = image.ImageDescription;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_AddImage";

                SqlParameter inputAddress = new SqlParameter("@address", address);
                SqlParameter inputUrl = new SqlParameter("@url", url);
                SqlParameter inputDescription = new SqlParameter("@description", desc);

                inputAddress.SqlDbType = SqlDbType.VarChar;
                inputUrl.SqlDbType = SqlDbType.VarChar;
                inputDescription.SqlDbType = SqlDbType.VarChar;

                inputAddress.Size = 50;
                inputUrl.Size = 500;
                inputDescription.Size = 50;


                SQLcmd.Parameters.Add(inputAddress);
                SQLcmd.Parameters.Add(inputUrl);
                SQLcmd.Parameters.Add(inputDescription);

                rowsAffected = objDB.DoUpdate(SQLcmd);

                if (rowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex) { return false; }
        }

        [HttpDelete]
        public Boolean Delete(int id)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_RemoveHouse";

                SqlParameter inputID = new SqlParameter("@id", id);

                inputID.SqlDbType = SqlDbType.Int;

                inputID.Size = 500;

                SQLcmd.Parameters.Add(inputID);

                rowsAffected = objDB.DoUpdate(SQLcmd);

                if (rowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex) { return false; }
        }

        public void DeleteImages(String address)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_DeleteImages";

                SqlParameter inputAddress = new SqlParameter("@address", address);

                inputAddress.SqlDbType = SqlDbType.VarChar;

                inputAddress.Size = 50;

                SQLcmd.Parameters.Add(inputAddress);

                rowsAffected = objDB.DoUpdate(SQLcmd);
            }
            catch (Exception ex) { }
        }

        public void DeleteRooms(String address)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_DeleteRooms";

                SqlParameter inputAddress = new SqlParameter("@address", address);

                inputAddress.SqlDbType = SqlDbType.VarChar;

                inputAddress.Size = 50;

                SQLcmd.Parameters.Add(inputAddress);

                rowsAffected = objDB.DoUpdate(SQLcmd);
            }
            catch (Exception ex) { }
        }

        [HttpGet("Comments/{address}")]
        public List<Comment> GetComments(String address)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetCommentsForHouse";

            SqlParameter inputAddress = new SqlParameter("@address", address);

            inputAddress.SqlDbType = SqlDbType.VarChar;

            inputAddress.Size = 500;

            SQLcmd.Parameters.Add(inputAddress);

            DataSet ds = objDB.GetDataSet(SQLcmd);
            DataTable record = ds.Tables[0];

            List<Comment> comments = new List<Comment>();

            foreach (DataRow dr in record.Rows)
            {
                Comment comment = new Comment();
                comment.Username = dr["Username"].ToString();
                comment.Content = dr["Comment"].ToString();
                comments.Add(comment);
            }

            return comments;
        }

        [HttpGet("Images/{address}")]
        public List<HouseImage> GetImages(String address)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetImages";

            SqlParameter inputAddress = new SqlParameter("@address", address);

            inputAddress.SqlDbType = SqlDbType.VarChar;

            inputAddress.Size = 50;

            SQLcmd.Parameters.Add(inputAddress);

            DataSet ds = objDB.GetDataSet(SQLcmd);
            DataTable record = ds.Tables[0];

            List<HouseImage> images = new List<HouseImage>();

            foreach (DataRow dr in record.Rows)
            {
                HouseImage image = new HouseImage();
                image.Address = dr["Address"].ToString();
                image.Url = dr["ImageUrl"].ToString();
                image.ImageDescription = dr["ImageDescription"].ToString();
                images.Add(image);
            }

            return images;
        }

        public House createHouseObj(DataRow record)
        {
            House house = new House();
            int houseID;
            int homeSize;
            int numberOfBedrooms;
            int houseYear;
            decimal askingPrice;
            int numberOfBathrooms;
            int sellerID;
            int realEstateID;

            if (!int.TryParse(record["Id"].ToString(), out houseID))
                houseID = -1;

            if (!int.TryParse(record["HomeSize"].ToString(), out homeSize))
                homeSize = -1;

            if (!int.TryParse(record["NumberOfBedrooms"].ToString(), out numberOfBedrooms))
                numberOfBedrooms = -1;

            if (!int.TryParse(record["HouseYear"].ToString(), out houseYear))
                houseYear = -1;

            if (!decimal.TryParse(record["AskingPrice"].ToString(), out askingPrice))
                askingPrice = -1;

            if (!int.TryParse(record["NumberOfBathrooms"].ToString(), out numberOfBathrooms))
                numberOfBathrooms = -1;

            if (!int.TryParse(record["SellerID"].ToString(), out sellerID))
                sellerID = -1;

            if (!int.TryParse(record["RealEstateId"].ToString(), out realEstateID))
                realEstateID = -1;

            house.HouseID = houseID;
            house.Address = record["Address"].ToString();
            house.PropertyType = record["PropertyType"].ToString();
            house.HomeSize = homeSize;
            house.Rooms = GetRooms(house.Address);
            house.NumberOfBedrooms = numberOfBedrooms;
            house.Amenities = record["Amentities"].ToString();
            house.HouseYear = houseYear;
            house.Garage = record["Garage"].ToString();
            house.Utilities = record["Utilities"].ToString();
            house.HomeDescription = record["HomeDescription"].ToString();
            house.AskingPrice = askingPrice;
            house.HouseImages = record["HouseImages"].ToString();
            house.NumberOfBathrooms = numberOfBathrooms;
            house.State = record["State"].ToString();
            house.City = record["City"].ToString();
            house.SellerID = sellerID;
            house.RealEstateID = realEstateID;

            return house;
        }

        public List<Room> GetRooms(String a)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            SQLcmd.CommandType = CommandType.StoredProcedure;
            SQLcmd.CommandText = "TP_GetRoomSizes";

            SqlParameter inputAddress = new SqlParameter("@address", a);

            inputAddress.SqlDbType = SqlDbType.VarChar;

            inputAddress.Size = 50;

            SQLcmd.Parameters.Add(inputAddress);

            DataSet ds = objDB.GetDataSet(SQLcmd);

            List<Room> rooms = new List<Room>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                Room room = new Room();
                room.RoomSizeL = int.Parse(record["RoomSizeL"].ToString());
                room.RoomSizeW = int.Parse(record["RoomSizeW"].ToString());
                room.RoomDescription = record["RoomDescription"].ToString();
                rooms.Add(room);
            }

            return rooms;
        }

        public void PutRooms(House house)
        {

            int rowsAffected = 0;

            List<Room> rooms = house.Rooms;

            SqlParameter inputAddress = new SqlParameter();
            SqlParameter inputL = new SqlParameter();
            SqlParameter inputW = new SqlParameter();
            SqlParameter inputDescription = new SqlParameter();

            foreach (Room room in rooms)
            {
                try
                {
                    SqlCommand SQLcmd = new SqlCommand();
                    DBConnect objDB = new DBConnect();

                    SQLcmd.CommandType = CommandType.StoredProcedure;
                    SQLcmd.CommandText = "TP_PutRoomSize";

                    inputAddress = new SqlParameter("@address", house.Address);
                    inputL = new SqlParameter("@l", room.RoomSizeL);
                    inputW = new SqlParameter("@w", room.RoomSizeW);
                    inputDescription = new SqlParameter("@desc", room.RoomDescription);

                    inputAddress.SqlDbType = SqlDbType.VarChar;
                    inputL.SqlDbType = SqlDbType.Int;
                    inputW.SqlDbType = SqlDbType.Int;
                    inputDescription.SqlDbType = SqlDbType.VarChar;

                    inputAddress.Size = 50;
                    inputL.Size = 50;
                    inputW.Size = 50;
                    inputDescription.Size = 50;


                    SQLcmd.Parameters.Add(inputAddress);
                    SQLcmd.Parameters.Add(inputL);
                    SQLcmd.Parameters.Add(inputW);
                    SQLcmd.Parameters.Add(inputDescription);

                    rowsAffected = objDB.DoUpdate(SQLcmd);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public int GetTotalSize(House house)
        {
            int total = 0;
            foreach (Room room in house.Rooms)
            {
                total += room.RoomSizeL + room.RoomSizeW;
            }

            return total;
        }

        [HttpPost("UpdateHouse")]
        public Boolean updateHouse([FromBody] House house)
        {
            try
            {
                SqlCommand SQLcmd = new SqlCommand();
                DBConnect objDB = new DBConnect();

                int rowsAffected = 0;

                int id = house.HouseID;
                String address = house.Address;
                String propertyType = house.PropertyType;
                int numberOfBedrooms = house.NumberOfBedrooms;
                String amenities = house.Amenities;
                int houseYear = house.HouseYear;
                int homeSize = house.HomeSize;
                String garage = house.Garage;
                String utilities = house.Utilities;
                String homeDescription = house.HomeDescription;
                float askingPrice = float.Parse(house.AskingPrice.ToString());
                String houseImages = house.HouseImages;
                int numberOfBathrooms = house.NumberOfBathrooms;
                String state = house.State;
                String city = house.City;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_UpdateHouses";

                SqlParameter inputID = new SqlParameter("@theHouseID", id);
                SqlParameter inputAmenities = new SqlParameter("@theAmentities", amenities);
                SqlParameter inputState = new SqlParameter("@theState", state);
                SqlParameter inputPrice = new SqlParameter("@thePrice", askingPrice);
                SqlParameter inputCity = new SqlParameter("@theCity", city);
                SqlParameter inputGarage = new SqlParameter("@theGarage", garage);
                SqlParameter inputDescription = new SqlParameter("@theHomeDescription", homeDescription);
                SqlParameter inputSize = new SqlParameter("@theHomeSize", homeSize);
                SqlParameter inputImages = new SqlParameter("@theHouseImages", houseImages);
                SqlParameter inputHouseYear = new SqlParameter("@theHouseYear", houseYear);
                SqlParameter inputNumOfBathrooms = new SqlParameter("@theNumOfBathroom", numberOfBathrooms);
                SqlParameter inputNumOfBedrooms = new SqlParameter("@theNumOfBedrooms", numberOfBedrooms);
                SqlParameter inputPropertyType = new SqlParameter("@thePropertyType", propertyType);
                SqlParameter inputUtilities = new SqlParameter("@theUtilities", utilities);

                inputID.SqlDbType = SqlDbType.Int;
                inputAmenities.SqlDbType = SqlDbType.VarChar;
                inputState.SqlDbType = SqlDbType.VarChar;
                inputPrice.SqlDbType = SqlDbType.Float;
                inputCity.SqlDbType = SqlDbType.VarChar;
                inputGarage.SqlDbType = SqlDbType.VarChar;
                inputDescription.SqlDbType = SqlDbType.VarChar;
                inputSize.SqlDbType = SqlDbType.Int;
                inputImages.SqlDbType = SqlDbType.VarChar;
                inputHouseYear.SqlDbType = SqlDbType.Int;
                inputNumOfBathrooms.SqlDbType = SqlDbType.Int;
                inputNumOfBedrooms.SqlDbType = SqlDbType.Int;
                inputPropertyType.SqlDbType = SqlDbType.VarChar;
                inputUtilities.SqlDbType = SqlDbType.VarChar;

                inputID.Size = 500;
                inputAmenities.Size = 500;
                inputState.Size = 500;
                inputPrice.Size = 500;
                inputCity.Size = 500;
                inputGarage.Size = 500;
                inputDescription.Size = 500;
                inputSize.Size = 500;
                inputImages.Size = 500;
                inputHouseYear.Size = 500;
                inputNumOfBathrooms.Size = 500;
                inputNumOfBedrooms.Size = 500;
                inputPropertyType.Size = 500;
                inputUtilities.Size = 500;


                SQLcmd.Parameters.Add(inputID);
                SQLcmd.Parameters.Add(inputAmenities);
                SQLcmd.Parameters.Add(inputState);
                SQLcmd.Parameters.Add(inputPrice);
                SQLcmd.Parameters.Add(inputCity);
                SQLcmd.Parameters.Add(inputGarage);
                SQLcmd.Parameters.Add(inputDescription);
                SQLcmd.Parameters.Add(inputSize);
                SQLcmd.Parameters.Add(inputImages);
                SQLcmd.Parameters.Add(inputHouseYear);
                SQLcmd.Parameters.Add(inputNumOfBathrooms);
                SQLcmd.Parameters.Add(inputNumOfBedrooms);
                SQLcmd.Parameters.Add(inputPropertyType);
                SQLcmd.Parameters.Add(inputUtilities);

                rowsAffected = objDB.DoUpdate(SQLcmd);

                DeleteRooms(house.Address);
                PutRooms(house);

                if (rowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex) { return false; }
        }

        [HttpGet("GetStatus")]
        public String getStatus(int id)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_GetHouseStatus";

                SqlParameter inputID = new SqlParameter("@id", id);

                inputID.SqlDbType = SqlDbType.Int;

                inputID.Size = 500;


                SQLcmd.Parameters.Add(inputID);

                DataSet ds = objDB.GetDataSet(SQLcmd);

                String status = ds.Tables[0].Rows[0]["HouseStatus"].ToString();

                return status;
            }
            catch (Exception ex) { return null; }
        }

        [HttpGet("UpdateStatus")]
        public Boolean updateStatus(int id, String status)
        {
            SqlCommand SQLcmd = new SqlCommand();
            DBConnect objDB = new DBConnect();

            try
            {
                int rowsAffected = 0;

                SQLcmd.CommandType = CommandType.StoredProcedure;
                SQLcmd.CommandText = "TP_UpdateHouseStatus";

                SqlParameter inputID = new SqlParameter("@theHouseID", id);
                SqlParameter inputStatus = new SqlParameter("@theHouseStatus", status);

                inputID.SqlDbType = SqlDbType.Int;
                inputStatus.SqlDbType = SqlDbType.VarChar;

                inputID.Size = 500;
                inputStatus.Size = 500;


                SQLcmd.Parameters.Add(inputID);
                SQLcmd.Parameters.Add(inputStatus);

                rowsAffected = objDB.DoUpdate(SQLcmd);

                if (rowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
