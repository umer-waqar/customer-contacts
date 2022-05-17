using AutoMapper;
using Customer.Services.ContactAPI.Models;
using Customer.Services.ContactAPI.Models.Dto;

namespace Customer.Services.ContactAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ContactDto, Contact>();
                config.CreateMap<Contact, ContactDto>();
            });
            return mappingConfig;   
        }
    }
}
