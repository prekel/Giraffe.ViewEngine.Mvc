using System;
using System.Linq;

namespace ModuleGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(Giraffe.ViewEngine.Mvc.Sample.Views.HomeModule);
            var ms = t.GetMethods();
            var m = ms.First();
            var y = m.Invoke(null, new object?[1]);

            Console.WriteLine("Hello World!");
        }
    }
}
