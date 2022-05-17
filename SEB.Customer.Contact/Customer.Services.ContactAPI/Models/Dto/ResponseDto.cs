
using System.Collections.Generic;

namespace Customer.Services.ContactAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public string DisplayMessage { get; set; } = string.Empty;
        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
