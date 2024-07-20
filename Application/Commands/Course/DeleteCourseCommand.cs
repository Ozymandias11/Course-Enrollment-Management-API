using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Course
{
   public sealed record DeleteCourseCommand(Guid id, bool trackChanges) : IRequest
    {
    }
}
