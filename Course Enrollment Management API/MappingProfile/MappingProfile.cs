using Application.Dtos.Student;
using AutoMapper;
using Entities.Models;

namespace Course_Enrollment_Management_APi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentForCreationDto, Student>();
        }
    }
}
