using Project2Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Utils
{
    public static class StringExtensions
    {
        public static string[] ToColumns(this string source)
        {
            return source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
        }

        public static Car ToCar(this string source)
        {
            var cols = source.ToColumns();

            return new Car(
                Id: Guid.NewGuid(),
                Year: int.Parse(cols[0]),
                Make: cols[1],
                Model: cols[2],
                Displacement: double.Parse(cols[3]),
                Cylinders: int.Parse(cols[4]),
                CityFe: int.Parse(cols[5]),
                HighwayFe: int.Parse(cols[6]),
                CombinedFe: int.Parse(cols[7])
            );
        }

        public static Manufacturer ToManufacturer(this string source)
        {
            var cols = source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();

            return new Manufacturer(
                Name: cols[0],
                Country: cols[1],
                Year: int.Parse(cols[2])
            );
        }
    }
}
