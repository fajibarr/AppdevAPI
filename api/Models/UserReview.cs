using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserReview
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(500)]
        public string Review { get; set; } = string.Empty;

        [Required]
        public DateTime DateWritten { get; set; } = DateTime.Now;

        [Required]
        public int Rating { get; set; }

        public string FilePath { get; set; } = string.Empty;
        public int? FoodItemId { get; set; } // FK of Food Item
        public FoodItem? FoodItem { get; set; } // Navigation prop to Food Item
        public int? UserId { get; set; } // FK of User
        public User? User { get; set; } // Navigation prop to User
    }
}