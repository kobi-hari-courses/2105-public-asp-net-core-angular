using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Model.Entities
{
    public record Course(
        int Id, 
        string Name, 
        string Category, 
        int InstructorId
        );
}
