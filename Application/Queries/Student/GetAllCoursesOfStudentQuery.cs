using Application.Dtos.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Student
{
   public sealed record GetAllCoursesOfStudentQuery(Guid studentId, bool trackChanges) : IRequest<IEnumerable<CourseDto>>
    {
    }
}
