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
    internal sealed class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateCourseHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseEntity = await _repositoryManager.CourseRepository.GetCourseById(request.course.Id, request.trackChanges);

            _mapper.Map(request.course, courseEntity);

            await _repositoryManager.SaveChanges();

            return Unit.Value;

        }
    }
}
