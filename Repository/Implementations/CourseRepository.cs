using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCourse(Course course) => Create(course);
       

        public void DeleteCourse(Course course) => Delete(course);


        public async Task<IEnumerable<Course>> GetAllCourses(bool trackChanges)
             => await FindAll(trackChanges).ToListAsync();

        public async Task<Course?> GetCourseById(Guid id, bool trackChanges)
           => await FindByCondition(c => c.Id == id, trackChanges).FirstOrDefaultAsync();
    }
}
