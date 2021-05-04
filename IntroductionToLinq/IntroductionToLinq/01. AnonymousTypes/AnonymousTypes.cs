using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IntroductionToLinq
{
    /*
     * Anonymous types are class types that derive directly from object,
     * and that cannot be cast to any type except object.
     *
     * The compiler provides a name for each anonymous type, although your application cannot access it.
     * From the perspective of the common language runtime, an anonymous type is no different from any
     * other reference type.
     *
     * Declare an instance of an anonymous type with var
     *
     * You cannot declare a field, a property, an event, or the return type of a method
     * as having an anonymous type.
     * Similarly, you cannot declare a formal parameter of a method, property, constructor,
     * or indexer as having an anonymous type.
     *
     * To pass an anonymous type, or a collection that contains anonymous types,
     * as an argument to a method, you can declare the parameter as type object.
     * However, doing this defeats the purpose of strong typing.
     *
     * So, anonymous types are most useful inside a method.
     */

    class AnonymousTypes
    {
        object FullName = new { FirstName = "Bill", LastName = "Gates"};
        
        // Does not compile
        // static var BillGates = new { FirstName = "Bill", LastName = "Gates" };

        public void Run()
        {
            var name = new { FirstName = "Bill", LastName = "Gates"};

            Console.WriteLine($"{name.FirstName} {name.LastName}");
        }
    }
}
