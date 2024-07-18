using Application.Dtos.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Course
{
   public sealed record GetAllCoursesQuery(bool trackChanges) : IRequest<IEnumerable<CourseDto>>
    {
    }
}
