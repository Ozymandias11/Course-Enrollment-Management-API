using Application.Commands.Course;
using Course_Enrollment_Management_APi.Requests.Course;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Course
{
    public class DeleteCourseEndpoint : Endpoint<DeleteCourseRequest, EmptyResponse>
    {
        private readonly ISender _sender;
        public DeleteCourseEndpoint(ISender sender) => _sender = sender;


        public override void Configure()
        {
            Delete("/api/courses/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteCourseRequest req, CancellationToken ct)
        {
            var command = new DeleteCourseCommand(req.Id, trackChanges: false);

            await _sender.Send(command, ct);

            await SendNoContentAsync(ct);

        }



    }
}
