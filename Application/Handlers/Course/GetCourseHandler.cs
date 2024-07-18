using Application.Dtos.Course;
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
    internal class GetCourseHandler : IRequestHandler<GetSingleCourseQuery, CourseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetCourseHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<CourseDto> Handle(GetSingleCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _repositoryManager.CourseRepository.GetCourseById(request.Id, request.trackChanges);

            var courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;   

        }
    }
}
