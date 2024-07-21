using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Enrollment
{
   public sealed record AssignCoursesToStudentCommand(Guid studentId, List<Guid> courseIds) : IRequest
    {
    }
}
