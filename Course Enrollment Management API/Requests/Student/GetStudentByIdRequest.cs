using FastEndpoints;

namespace Course_Enrollment_Management_APi.Requests.Student
{
    public class GetStudentByIdRequest
    {
        [BindFrom("id")]
        public Guid Id { get; set; }    
    }
}
