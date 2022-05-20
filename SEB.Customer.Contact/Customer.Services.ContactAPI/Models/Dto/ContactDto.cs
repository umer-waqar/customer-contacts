using System;
using Customer.Services.ContactAPI.Validation;
using System.ComponentModel.DataAnnotations;

namespace Customer.Services.ContactAPI.Models.Dto
{
    //Customer contact information consists of essentially 3 parts:
    //1. The social security number(10-12 digits)
    //2. A valid email address or NULL
    //3. A valid phone number or NULL(assume an optional +46 as county code followed by a 9-digit telephone number)

    public class ContactDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage = "Social Security Number is required.")]
        [MinLength(10, ErrorMessage = "Social Security Number should be minimum 10 digit long.")]
        [MaxLength(12, ErrorMessage = "Social Security Number should be maximum 12 digit long.")]
        [Range(0, UInt64.MaxValue, ErrorMessage = "Please enter valid social security number")] //Number only
        [PersonalNumber("Social Security Number should start from 19 or 20")]
        public string PersonalNumber { get; set; }

        
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]  //Buit in Emaill Address Validation
        public string Email { get; set; }


        //https://www.oreilly.com/library/view/regular-expressions-cookbook/9781449327453/ch04s03.html
        //This phone number validation need to improved. Not fully tested. Copy from above url.

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\+(?:[0-9]●?){6,14}[0-9]$", ErrorMessage = "Invalid Phone Number")]       
        public string Phone { get; set; }
    }
}
