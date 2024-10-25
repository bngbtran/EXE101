using System.ComponentModel.DataAnnotations;

namespace NiceHouse.Models
    {
        public class Dormitory
            {
                public int Id { get; set; }

                [Required]
                [StringLength(100)]
                public string Name { get; set; }

                [Required]
                public DormitoryType Type { get; set; }

                [Required]
                [StringLength(200)]
                public string Address { get; set; }

                [StringLength(500)]
                public string Description { get; set; }

                [Required]
                public decimal MaxRoomPrice { get; set; }

                [Required]
                public decimal MinRoomPrice { get; set; }

                public ICollection<DormitoryImage> Images { get; set; }

                [Required]
                public int NumberOfPeople { get; set; }

                public ICollection<RoomType> RoomTypes { get; set; }

                public ICollection<Room> Rooms { get; set; }
            }

//------------------------------------------------------------------------------

        public enum DormitoryType
            {
                HighEndApartment,
                SocialHousing,
                AffordableDormitory
            }
    }