namespace NiceHouse.Models
    {
        public class HotelImage
            {
                public int Id { get; set; }

                public int HotelId { get; set; }

                public string ImageUrl { get; set; }

                public virtual Hotel Hotel { get; set; }
            }
    }