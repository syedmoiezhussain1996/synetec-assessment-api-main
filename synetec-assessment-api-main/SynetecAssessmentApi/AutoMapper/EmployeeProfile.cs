using AutoMapper;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi.AutoMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            DefineReadMapping();
        }
        private void DefineReadMapping()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Fullname, o => o.MapFrom(s => s.Fullname))
                .ForMember(d => d.JobTitle, o => o.MapFrom(s => s.JobTitle))
                .ForMember(d => d.Salary, o => o.MapFrom(s => s.Salary))
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department))
                
            ;

            CreateMap<Department, DepartmentDto>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForAllOtherMembers(o => o.Ignore())
            ;
        }
    }
}
