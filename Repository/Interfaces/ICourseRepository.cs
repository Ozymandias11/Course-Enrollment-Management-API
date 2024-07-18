using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses(bool trackChanges);
        Task<Course?> GetCourseById(Guid id, bool trackChanges);    
        void CreateCourse(Course course);   
        void DeleteCourse(Course course);   

    }
}
    