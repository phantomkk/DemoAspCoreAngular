using AutoMapper;
using Demo.DataAccess.Models;
using DemoProject.Models;

namespace DemoProject.MappingProfiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
