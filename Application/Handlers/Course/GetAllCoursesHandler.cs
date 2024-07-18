using Application.Dtos.Course;
using Application.Dtos.Student;
using Application.Queries.Course;
using AutoMapper;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Course
{
    internal class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllCoursesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _repositoryManager.CourseRepository.GetAllCourses(request.trackChanges);

            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return coursesDto;


        }
    }
}
