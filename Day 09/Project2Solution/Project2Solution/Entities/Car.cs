using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Entities
{
    public record Car(
        Guid Id, 
        int Year,
        string Make,
        string Model,
        double Displacement,
        int Cylinders,
        int CityFe,
        int HighwayFe, 
        int CombinedFe
        );
}
