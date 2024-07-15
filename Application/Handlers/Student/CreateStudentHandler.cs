using Application.Commands.Student;
using Application.Dtos.Student;
using AutoMapper;
using Entities.Models;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Student
{
    internal sealed class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateStudentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  
        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Entities.Models.Student>(request.student);

            _repositoryManager.StudentRepository.CreateStudent(studentEntity);

            await _repositoryManager.SaveChanges();
            
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);

            return studentToReturn;


        }
    }
}
