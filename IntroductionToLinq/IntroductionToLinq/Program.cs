using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    // The examples in this lesson are based on this tutorial:
    // https://docs.microsoft.com/en-us/samples/dotnet/try-samples/101-linq-samples/

    internal static class Program
    {
        static void Main(string[] args)
        {
            RunSamples();
        }

        private static void RunSamples()
        {
            // 01 Representation

            new AnonymousTypes().Run();
            new Tuples().Run();

            // 02 Sequence Generation

            new GenerationSample().Run();

            // 03 Projection

            new SelectSample().Run();
            new SelectManySample().Run();

            // 04 Aggregator operators 

            new AggregatorsSample().Run();

            // 05 Restriction operators (filtering)

            new WhereSample().Run();

            // 06 Ordering operators 

            new OrderingSample().Run();

            // 07 Partitioning operators

            new PartitionSample().Run();

            // 08 Conversion operators 

            new ConversionSample().Run();

            // 09 Grouping operators 

            new GroupingSample().Run();

            // 10 Set operators 

            new SetOperatorsSample().Run();

            // 11 Element operators 

            new ElementOperatorsSample().Run();
        }
    }
}
