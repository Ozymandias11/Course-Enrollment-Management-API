using Application.Dtos.Course;
using Application.Queries.Student;
using AutoMapper;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Student
{
    internal sealed class GetAllCoursesOfStudentHandler : IRequestHandler<GetAllCoursesOfStudentQuery, IEnumerable<CourseDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllCoursesOfStudentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesOfStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentById(request.studentId, request.trackChanges);

            var enrolledCourseDto = _mapper.Map<IEnumerable<CourseDto>>(student?.Enrollments?.Select(e => e.Course));

            return enrolledCourseDto;



        }
    }
}
