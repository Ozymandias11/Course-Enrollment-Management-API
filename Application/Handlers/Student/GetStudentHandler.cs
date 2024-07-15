using Application.Dtos.Student;
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
    internal class GetStudentHandler : IRequestHandler<GetSingleStudentQuery, StudentDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetStudentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentById(request.id, request.trackChanges);

            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;

        }
    }
}
