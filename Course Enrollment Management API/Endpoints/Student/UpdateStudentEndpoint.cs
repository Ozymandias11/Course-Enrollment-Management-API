using Application.Commands.Student;
using Application.Dtos.Student;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Student
{
    public class UpdateStudentEndpoint : Endpoint<StudentForUpdateDto, EmptyResponse>
    {
        private readonly ISender _sender;
        public UpdateStudentEndpoint(ISender sender) => _sender = sender;


        public override void Configure()
        {
            Put("/api/students/{id}");
            AllowAnonymous();
        }


        public override async Task HandleAsync(StudentForUpdateDto req, CancellationToken ct)
        {
            var command = new UpdateStudentCommand(req, trackChanges:true);
            await _sender.Send(command, ct);
            await SendNoContentAsync(ct);
        }



    }
}
