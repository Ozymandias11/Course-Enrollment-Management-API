using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Course_Enrollment_Management_APi.Requests.Student
{
    public class DeleteStudentRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }    
    }
}
