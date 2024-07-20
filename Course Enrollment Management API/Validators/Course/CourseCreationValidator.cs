using Application.Dtos.Course;
using FastEndpoints;
using FluentValidation;

namespace Course_Enrollment_Management_APi.Validators.Course
{
    public class CourseCreationValidator : Validator<CourseForCreationDto>
    {
        public CourseCreationValidator()
        {
            RuleFor(c => c.Title)
                 .NotEmpty().WithMessage("Course Title is Required");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Course Description is required");

            RuleFor(c => c.Credits)
                .NotEmpty().InclusiveBetween(2, 10)
                .WithMessage("Credits Should be Between 2 and 10");
        }
    }
}
