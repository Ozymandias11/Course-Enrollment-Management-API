using Application.Commands.Student;
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
    internal sealed class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateStudentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = await _repositoryManager.StudentRepository.GetStudentById(request.student.Id, request.trackChanges);

            _mapper.Map(request.student, studentEntity);

            await _repositoryManager.SaveChanges();

            return Unit.Value;

        }
    }
}
