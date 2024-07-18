using FastEndpoints;

namespace Course_Enrollment_Management_APi.Requests.Course
{
    public class GetCourseByIdRequest
    {
        [BindFrom("id")]
        public Guid Id {  get; set; }
    }
}
