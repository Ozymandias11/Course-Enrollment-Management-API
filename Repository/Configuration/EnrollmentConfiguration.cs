using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.StudentId, e.CourseId });

            builder.HasData(
                new Enrollment
                {
                    StudentId = new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"),
                    CourseId = new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"),
                    EnrollmentDate = DateTime.Now
                },
                new Enrollment
                {
                    StudentId = new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"),
                    CourseId = new Guid("85146c4f-7280-486e-89a1-05b7d325ef68"),
                    EnrollmentDate = DateTime.Now
                },
                new Enrollment
                {
                    StudentId = new Guid("ef55f7eb-56cf-48f9-a37b-fab724f21061"),
                    CourseId = new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"),
                    EnrollmentDate = DateTime.Now
                }
            );
        }
    }
}
