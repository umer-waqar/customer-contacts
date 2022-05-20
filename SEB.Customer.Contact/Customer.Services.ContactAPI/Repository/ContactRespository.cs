using AutoMapper;
using Customer.Services.ContactAPI.DbContexts;
using Customer.Services.ContactAPI.Models;
using Customer.Services.ContactAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Services.ContactAPI.Repository
{
    public class ContactRespository : IContactRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ContactRespository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ContactDto> CreateUpdateContact(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<ContactDto, Contact>(contactDto);
            if (contact.Id > 0)
            {
                _db.Contacts.Update(contact);
            }
            else
            {
                _db.Contacts.Add(contact);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Contact, ContactDto>(contact);
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            try
            {
                Contact contact = await _db.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);
                if (contact == null)
                {
                    return false;
                }
                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<ContactDto> GetContactById(int contactId)
        {
            Contact contact = await _db.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            List<Contact> contacts = await _db.Contacts.ToListAsync();
            return _mapper.Map<List<ContactDto>>(contacts);
        }
    }
}
