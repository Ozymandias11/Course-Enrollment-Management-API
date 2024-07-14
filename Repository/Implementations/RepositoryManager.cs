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
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        }

        public IStudentRepository StudentRepository => _studentRepository.Value;

        public async Task SaveChanges() => await _repositoryContext.SaveChangesAsync(); 
     
    }
}
