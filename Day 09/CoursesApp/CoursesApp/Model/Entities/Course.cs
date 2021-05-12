using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Model.Entities
{
    public record Course(
        Guid Id, 
        string Name, 
        string Category, 
        Guid InstructorId
        );
}
