using Application.Commands.Enrollment;
using AutoMapper;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Enrollment
{
    public class AssignCoursesToStudentHandler : IRequestHandler<AssignCoursesToStudentCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AssignCoursesToStudentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AssignCoursesToStudentCommand request, CancellationToken cancellationToken)
        {
            foreach(var courseId in request.courseIds)
            {
                _repositoryManager.EnrollmentRepository.CreateEnrollment(request.studentId, courseId);
            }

            await _repositoryManager.SaveChanges();

            return Unit.Value;  

        }
    }
}
