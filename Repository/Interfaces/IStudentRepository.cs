using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents(bool trackChanges);
        Task<Student?> GetStudentById(Guid id, bool trackChanges);  
        void CreateStudent(Student student);    
    }
}
