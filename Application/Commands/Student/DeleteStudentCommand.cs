using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Student
{
    public record DeleteStudentCommand(Guid id, bool trackChanges) : IRequest;
    
    

}
