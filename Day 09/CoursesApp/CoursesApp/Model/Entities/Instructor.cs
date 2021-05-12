using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Model.Entities
{
    public record Instructor(
        Guid Id, 
        string Name
        );
}
