using NiceHouse.Models;

public class RoomTypeImage
    {
        public int Id { get; set; }

        public int RoomTypeId { get; set; }

        public string ImageUrl { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
