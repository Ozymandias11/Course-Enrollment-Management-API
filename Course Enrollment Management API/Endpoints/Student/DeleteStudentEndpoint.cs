using Application.Commands.Student;
using Application.Dtos.Student;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;
using System.Net;

namespace Course_Enrollment_Management_APi.Endpoints.Student
{
    public class DeleteStudentEndpoint : Endpoint<DeleteStudentRequest, EmptyResponse>
    {
        private readonly ISender _sender;
        public DeleteStudentEndpoint(ISender sender) => _sender = sender;

        public override void Configure()
        {
            Delete("/api/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteStudentRequest req, CancellationToken ct)
        {
            var command = new DeleteStudentCommand(req.Id, false);

            await _sender.Send(command,ct);

            await SendNoContentAsync(ct);

        }




    }
}
