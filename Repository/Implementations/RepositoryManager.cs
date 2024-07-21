using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IEnrollmentRepository> _enrollmentRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
            _courseRepository = new Lazy<ICourseRepository>(()  => new CourseRepository(repositoryContext));
            _enrollmentRepository = new Lazy<IEnrollmentRepository>(() => new EnrollmentRepository(repositoryContext));
        }

        public IStudentRepository StudentRepository => _studentRepository.Value;

        public ICourseRepository CourseRepository => _courseRepository.Value;

        public IEnrollmentRepository EnrollmentRepository => _enrollmentRepository.Value;

        public async Task SaveChanges() => await _repositoryContext.SaveChangesAsync(); 
     
    }
}
