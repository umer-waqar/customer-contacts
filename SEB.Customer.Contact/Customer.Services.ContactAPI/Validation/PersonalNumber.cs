using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Services.ContactAPI.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PersonalNumber : ValidationAttribute
    {
        public PersonalNumber(string errorMessage) : base(errorMessage)
        {

        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            if (value.ToString().Length == 12)  //User provide input with 12 character then personal number start with 19 or 20
            {
                return value.ToString().StartsWith("19") || value.ToString().StartsWith("20");
            }
            if (value.ToString().Length == 10)
            {
                return true;
            }
            return false;
        }
    }
}
