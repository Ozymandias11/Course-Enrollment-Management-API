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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Credits).IsRequired();

            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);


           
           builder.HasData(
           new Course
           {
               Id = new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"),
               Title = "Introduction to Computer Science",
               Description = "Fundamental concepts of programming",
               Credits = 3
           },
           new Course
           {
               Id = new Guid("85146c4f-7280-486e-89a1-05b7d325ef68"),
               Title = "Database Management",
               Description = "Principles of database design and management",
               Credits = 4
           }
          );

        }
    }
}
