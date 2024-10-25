using System.ComponentModel.DataAnnotations;

namespace NiceHouse.Models
    {
        public class DormitoryImage
            {
                public int Id { get; set; }

                public string Url { get; set; }

                [Required]
                public int DormitoryId { get; set; }

                public Dormitory Dormitory { get; set; }
            }
    }