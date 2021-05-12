using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Entities
{
    public record User(
        string Username, 
        string FirstName, 
        string LastName
        );
}
