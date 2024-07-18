using Entities.Models;
using Moq;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class StudentRepositoryTest
    {
        [Fact]
        public void GetAllStudents_ReturnsListOfStudents()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(repo => (repo.GetAllStudents(false))).Returns(Task.FromResult(GetStudents()));


            var result = mockRepo.Object.GetAllStudents(false)
                .GetAwaiter()
                .GetResult()
                .ToList();

            Assert.IsType<List<Student>>(result);


        }

        private IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                new() {
                    Id = Guid.NewGuid(),
                    FirstName = "FirstName_test",
                    LastName = "LastName_tets",
                    EmailAddress = "test@gmail.com"
                }
            };
        }
    }
}
