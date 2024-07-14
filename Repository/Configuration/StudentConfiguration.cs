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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.EmailAddress).IsRequired();

            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);


            builder.HasData(
            new Student
            {
                Id = new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"),
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john.doe@example.com"
            },
            new Student
            {
                Id = new Guid("ef55f7eb-56cf-48f9-a37b-fab724f21061"),
                FirstName = "Jane",
                LastName = "Smith",
                EmailAddress = "jane.smith@example.com"
            }
          );
        }
    }
}
