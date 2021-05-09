using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Solution.Entities
{
    public class Car
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double Displacement { get; set; }

        public int Cylinders { get; set; }

        public int CityFe { get; set; }

        public int HighwayFe { get; set; }

        public int CombinedFe { get; set; }
    }
}
