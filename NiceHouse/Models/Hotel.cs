namespace NiceHouse.Models
    {
        public class Hotel
            {
                public int Id { get; set; }

                public string Name { get; set; }

                public string Location { get; set; }

                public string Address { get; set; }

                public decimal? MinRoomPrice { get; set; }

                public decimal? MaxRoomPrice { get; set; }

                public ICollection<HotelImage> Images { get; set; }

                public ICollection<RoomType> RoomTypes { get; set; }

                public ICollection<Room> Rooms { get; set; }
            }
    }