using AutoMapper;
using ODataTest.Models;

namespace ODataTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}