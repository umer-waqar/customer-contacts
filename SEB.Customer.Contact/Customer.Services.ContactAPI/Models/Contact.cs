using System.ComponentModel.DataAnnotations;

namespace Customer.Services.ContactAPI.Models
{
    //Customer contact information consists of essentially 3 parts:
    //1. The social security number(10-12 digits)
    //2. A valid email address or NULL
    //3. A valid phone number or NULL(assume an optional +46 as county code followed by a 9-digit telephone number)

    public class Contact
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(10)]
        [MaxLength(12)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid social security number")]
        public string PersonalNumber { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
