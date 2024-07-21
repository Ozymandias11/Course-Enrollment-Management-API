using Entities.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEnrollment(Guid studentId, Guid courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,  
                CourseId = courseId,
                EnrollmentDate = DateTime.Now
            };

            Create(enrollment);

        }
    }
}
