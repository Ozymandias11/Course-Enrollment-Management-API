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
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public void CreateStudent(Student student) => Create(student);

        public void DeleteStudent(Student student) => Delete(student);
     

        public async Task<IEnumerable<Student>> GetAllStudents(bool trackChanges)
            => await FindAll(trackChanges).ToListAsync();

        public async Task<Student?> GetStudentById(Guid id, bool trackChanges)
            => await FindByCondition(s => s.Id == id, trackChanges).FirstOrDefaultAsync();
       
    }
}
