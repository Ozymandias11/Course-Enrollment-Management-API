using Application.Commands.Course;
using Application.Dtos.Course;
using Application.Dtos.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Course
{
    public class UpdateCourseEndpoint : Endpoint<CourseForUpdateDto ,EmptyResponse>
    {
        private readonly ISender _sender;
        public UpdateCourseEndpoint(ISender sender) => _sender = sender;

        public override void Configure()
        {
            Put("/api/courses/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CourseForUpdateDto req, CancellationToken ct)
        {
            var command = new UpdateCourseCommand(req, trackChanges:true);
            await _sender.Send(command, ct);
            await SendNoContentAsync(ct);
        }



    }
}
