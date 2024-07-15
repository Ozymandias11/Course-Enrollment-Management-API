using Application.Dtos.Student;
using Application.Queries.Student;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Student
{
    public class GetStudentByIdEndpoint : Endpoint<GetStudentByIdRequest, StudentDto>
    {
        private readonly ISender _sender;
        public GetStudentByIdEndpoint(ISender sender) => _sender = sender;

        public override void Configure()
        {
            Get("/api/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetStudentByIdRequest request ,CancellationToken ct)
        {
            var query = new GetSingleStudentQuery(request.Id, trackChanges: false);
            var result = await _sender.Send(query, ct);
            await SendAsync(result);
        }



    }
}
