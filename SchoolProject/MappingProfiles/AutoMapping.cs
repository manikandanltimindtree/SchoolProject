using AutoMapper;
using SchoolProject.DTO.Students;
using SchoolProject.Models;

namespace SchoolProject.MappingProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
        }
    }
}
