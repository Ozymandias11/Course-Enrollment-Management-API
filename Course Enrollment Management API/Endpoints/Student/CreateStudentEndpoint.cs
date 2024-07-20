using Application.Commands.Student;
using Application.Dtos.Student;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Student
{
    public class CreateStudentEndpoint : Endpoint<StudentForCreationDto, StudentDto>
    {
        private readonly ISender _sender;
        public CreateStudentEndpoint(ISender sender) => _sender = sender;


        public override void Configure()
        {
            Post("/api/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StudentForCreationDto req, CancellationToken ct)
        {
            var command = new CreateStudentCommand(req);
            var result = await _sender.Send(command, ct);
            await SendAsync(result, 201, ct);
        }


    }
}
