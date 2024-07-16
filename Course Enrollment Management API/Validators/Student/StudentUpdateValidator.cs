using Application.Dtos.Student;
using FastEndpoints;
using FluentValidation;

namespace Course_Enrollment_Management_APi.Validators.Student
{
    public class StudentUpdateValidator : Validator<StudentForUpdateDto>
    {
        public StudentUpdateValidator()
        {
            RuleFor(s => s.FirstName)
               .NotEmpty().WithMessage("First Name is required");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(s => s.EmailAddress)
                .NotEmpty().WithMessage("Email is Required")
                .EmailAddress().WithMessage("A valid email address format is required");
        }
    }
}
