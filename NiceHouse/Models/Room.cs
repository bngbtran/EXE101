namespace NiceHouse.Models
    {
        public class Room
            {
                public int Id { get; set; }

                public int HotelId { get; set; }

                public int RoomTypeId { get; set; }

                public bool IsAvailable { get; set; }

                public virtual Hotel Hotel { get; set; }

                public virtual RoomType RoomType { get; set; }
            }
    }