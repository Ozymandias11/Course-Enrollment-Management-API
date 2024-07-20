using Application.Commands.Course;
using Application.Dtos.Course;
using AutoMapper;
using Entities.Models;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Course
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, CourseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateCourseHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseEntity = _mapper.Map<Entities.Models.Course>(request.course);

            _repositoryManager.CourseRepository.CreateCourse(courseEntity);

            await _repositoryManager.SaveChanges();

            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
            
            return courseToReturn;

        }
    }
}
