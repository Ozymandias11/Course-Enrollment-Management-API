using Application.Dtos.Student;
using Application.Queries.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Student
{
    public class GetAllStudentsEndpoint : EndpointWithoutRequest<IEnumerable<StudentDto>>
    {
        private readonly ISender _sender;
        public GetAllStudentsEndpoint(ISender sender) => _sender = sender;

        public override void Configure()
        {
            Get("/api/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var query = new GetAllStudentsQuery(trackChanges: false);
            var result = await _sender.Send(query, ct);
            await SendAsync(result);
        }
    }
}
