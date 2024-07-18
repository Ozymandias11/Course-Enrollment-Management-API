using Application.Dtos.Course;
using Application.Queries.Course;
using Course_Enrollment_Management_APi.Requests.Course;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Course
{
    public class GetCourseByIdEndpoint : Endpoint<GetCourseByIdRequest, CourseDto>
    {
        private readonly ISender _sender;

        public GetCourseByIdEndpoint(ISender sender) => _sender = sender;

        public override void Configure()
        {
            Get("/api/courses/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetCourseByIdRequest request, CancellationToken ct)
        {
            var query = new GetSingleCourseQuery(request.Id, trackChanges: false);
            var result = await _sender.Send(query, ct);
            await SendAsync(result);
        }




    }
}
