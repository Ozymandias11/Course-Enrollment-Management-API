using Application.Dtos.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Student
{
    public sealed record CreateStudentCommand(StudentForCreationDto student) : IRequest<StudentDto>
    {

    }
}
