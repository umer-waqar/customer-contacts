using Customer.Services.ContactAPI.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Services.ContactAPI.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactDto>> GetContacts();
        Task<ContactDto> GetContactById(int contactId);
        Task<ContactDto> CreateUpdateContact(ContactDto contactDto); 
        Task<bool> DeleteContact(int contactId);  
    }
}
