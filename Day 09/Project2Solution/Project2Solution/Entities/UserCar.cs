using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Entities
{
    public record UserCar(
        string Username, 
        Guid CarId
        );
}
