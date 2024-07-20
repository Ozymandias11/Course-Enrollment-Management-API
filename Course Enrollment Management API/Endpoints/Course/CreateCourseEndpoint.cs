using Application.Commands.Course;
using Application.Dtos.Course;
using Course_Enrollment_Management_APi.Requests.Course;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Course
{
    public class CreateCourseEndpoint : Endpoint<CourseForCreationDto, CourseDto>
    {
        public ISender _sender;
        public CreateCourseEndpoint(ISender sender) => _sender = sender;



        public override void Configure()
        {
            Post("/api/courses");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CourseForCreationDto request, CancellationToken ct)
        {
            var command = new CreateCourseCommand(request);
            var result = await _sender.Send(command, ct);
            await SendAsync(result, 201, ct);
        }


    }
}
