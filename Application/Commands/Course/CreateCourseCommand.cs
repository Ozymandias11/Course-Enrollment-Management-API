﻿using Application.Dtos.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Course
{
    public sealed record CreateCourseCommand(CourseForCreationDto course) : IRequest<CourseDto>
    {
    }
}
