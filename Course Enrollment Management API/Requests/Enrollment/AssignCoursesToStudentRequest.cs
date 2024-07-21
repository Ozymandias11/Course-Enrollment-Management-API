using FastEndpoints;

namespace Course_Enrollment_Management_APi.Requests.Enrollment
{
    public class AssignCoursesToStudentRequest
    {
        [BindFrom("id")]
        public Guid StudentId { get; set; } 
        public List<Guid>? CourseIds { get; set; }
    }
}
