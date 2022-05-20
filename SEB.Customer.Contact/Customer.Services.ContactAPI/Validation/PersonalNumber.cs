using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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
            if (value != null)
            {
                if (value.ToString().Length == 12)
                {
                    return value.ToString().StartsWith("19") || value.ToString().StartsWith("20");
                }
                if (value.ToString().Length == 10)
                {
                    return true;
                }
            }
            return false;
        }      
    }
}
