using Customer.Services.ContactAPI.Models.Dto;
using Customer.Services.ContactAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Services.ContactAPI.Controllers
{
    [Route("api/contacts")]
    public class ContactAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IContactRepository _contactRepository;

        public ContactAPIController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> GetAsync()
        {
            try
            {
                _response.Result = await _contactRepository.GetContacts();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetAsync(int id)
        {
            try
            {
                _response.Result = await _contactRepository.GetContactById(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> PostAsync([FromBody] ContactDto contactDto)
        {
            try
            {
                _response.Result = await _contactRepository.CreateUpdateContact(contactDto);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> PutAsync([FromBody] ContactDto contactDto)
        {
            try
            {
                _response.Result = await _contactRepository.CreateUpdateContact(contactDto);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{id}")]        
        public async Task<object> DeleteAsync(int id)
        {
            try
            {
                _response.Result = await _contactRepository.DeleteContact(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }
    }
}
