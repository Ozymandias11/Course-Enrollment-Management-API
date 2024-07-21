using FastEndpoints;

namespace Course_Enrollment_Management_APi.Requests.Student
{
    public class GetAllCoursesOfStudentEndpointRequest
    {
        [BindFrom("id")]
        public Guid StudentId { get; set; } 
    }
}
