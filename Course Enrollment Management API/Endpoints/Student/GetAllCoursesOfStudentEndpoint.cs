using Application.Dtos.Course;
using Application.Queries.Student;
using Course_Enrollment_Management_APi.Requests.Student;
using FastEndpoints;
using MediatR;

namespace Course_Enrollment_Management_APi.Endpoints.Student
{
    public class GetAllCoursesOfStudentEndpoint : Endpoint<GetAllCoursesOfStudentEndpointRequest, IEnumerable<CourseDto>>
    {
        private readonly ISender _sender;
        public GetAllCoursesOfStudentEndpoint(ISender sender) => _sender = sender;

        public override void Configure()
        {
            Get("api/students/{id}/courses");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetAllCoursesOfStudentEndpointRequest req, CancellationToken ct)
        {
            var query = new GetAllCoursesOfStudentQuery(req.StudentId, false);
            var result = await _sender.Send(query, ct);
            await SendAsync(result);


        }



    }
}
