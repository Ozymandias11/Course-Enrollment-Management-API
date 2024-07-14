using Application.Dtos.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Student
{
   public sealed record GetAllStudentsQuery(bool trackChanges) : IRequest<IEnumerable<StudentDto>>
    {

    }
}
