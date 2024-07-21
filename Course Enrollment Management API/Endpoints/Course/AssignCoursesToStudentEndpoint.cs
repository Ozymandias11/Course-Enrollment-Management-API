using Application.Commands.Enrollment;
using Course_Enrollment_Management_APi.Requests.Enrollment;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Course
{
    public class AssignCoursesToStudentEndpoint : Endpoint<AssignCoursesToStudentRequest, EmptyResponse>
    {
        private readonly ISender _sender;
        public AssignCoursesToStudentEndpoint(ISender sender) => _sender = sender;


        public override void Configure()
        {
            Post("/api/students/{id}/assign-courses");
            Tags("students");
            AllowAnonymous();
        }
        public override async Task HandleAsync(AssignCoursesToStudentRequest request, CancellationToken ct)
        {
            var command = new AssignCoursesToStudentCommand(request.StudentId, request.CourseIds);

            await _sender.Send(command, ct);

            await SendNoContentAsync(ct);



        }


    }
}
