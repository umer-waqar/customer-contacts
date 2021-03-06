using Customer.Services.ContactAPI.Models.Dto;
using Customer.Services.ContactAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<object> GetsAsync()
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

        [HttpGet("{id}")]
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
                //Validate the input fields. Personal Number, Email Adddress and Phone Number
                if (ModelState.IsValid)
                {
                    //Unique Personal Number
                    var isPerNumExists = (await _contactRepository.GetContacts()).Any(x => string.Equals(x.PersonalNumber, contactDto.PersonalNumber, StringComparison.OrdinalIgnoreCase));
                    if (!isPerNumExists)
                    {
                        _response.Result = await _contactRepository.CreateUpdateContact(contactDto);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { "Your contact information already registered!" };
                    }
                }
                else
                {
                    _response.IsSuccess = false;
                    var errorMessages = ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage);
                    _response.ErrorMessages = errorMessages.ToList();
                }
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
                //Validate the input fields. Personal Number, Email and Phone
                if (ModelState.IsValid)
                {
                    _response.Result = await _contactRepository.CreateUpdateContact(contactDto);
                }
                else
                {
                    _response.IsSuccess = false;
                    var errorMessages = ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage);
                    _response.ErrorMessages = errorMessages.ToList();
                }
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
