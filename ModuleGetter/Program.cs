using System;
using System.Linq;
using System.Reflection;

namespace ModuleGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(Giraffe.ViewEngine.Mvc.Sample.Views.Home);
            var a = Assembly.GetAssembly(t);
            var y = a.DefinedTypes.Where(tp => tp.Namespace == "Giraffe.ViewEngine.Mvc.Sample.Views").ToList();

            
            
            Console.WriteLine("Hello World!");
        }
    }
}
