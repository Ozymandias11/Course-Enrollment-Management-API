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
    internal sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DeleteStudentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentById(request.id, request.trackChanges);

            _repositoryManager.StudentRepository.DeleteStudent(student);

            await _repositoryManager.SaveChanges();

            return Unit.Value;


        }
    }
}
