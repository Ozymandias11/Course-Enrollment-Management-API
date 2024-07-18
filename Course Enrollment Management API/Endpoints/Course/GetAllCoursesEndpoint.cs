using Application.Dtos.Course;
using Application.Queries.Course;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Course
{
    public class GetAllCoursesEndpoint : EndpointWithoutRequest<IEnumerable<CourseDto>>
    {
        private readonly ISender _sender;
        public GetAllCoursesEndpoint(ISender sender) => _sender = sender;


        public override void Configure()
        {
            Get("/api/courses");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var query = new GetAllCoursesQuery(trackChanges: false);
            var result = await _sender.Send(query, ct);
            await SendAsync(result);
        }




    }
}
