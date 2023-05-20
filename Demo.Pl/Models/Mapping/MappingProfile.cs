using AutoMapper;
using Demo.DAL.Entities;
using Demo.Pl.Models.ViewModels;

namespace Demo.Pl.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();

        }
    }
}
