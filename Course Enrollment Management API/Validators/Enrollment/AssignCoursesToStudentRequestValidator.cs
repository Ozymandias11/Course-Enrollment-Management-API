using Course_Enrollment_Management_APi.Requests.Enrollment;
using FastEndpoints;
using FluentValidation;

namespace Course_Enrollment_Management_APi.Validators.Enrollment
{
    public class AssignCoursesToStudentRequestValidator : Validator<AssignCoursesToStudentRequest>
    {
        public AssignCoursesToStudentRequestValidator()
        {
            RuleFor(e => e.StudentId)
                .NotEmpty().WithMessage("Student id is required");

            RuleFor(e => e.CourseIds)
                .NotNull()
                .Must(ids => ids != null && ids.Any())
                .WithMessage("At least one course must be provided");

        }
    }
}
