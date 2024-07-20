using Application.Commands.Course;
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
    internal class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DeleteCourseHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repositoryManager.CourseRepository.GetCourseById(request.id, request.trackChanges);

            _repositoryManager.CourseRepository.DeleteCourse(course);

            await _repositoryManager.SaveChanges();

            return Unit.Value;
        }
    }
}
