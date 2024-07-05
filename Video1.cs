using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_LemdaExpressions_And_Events
{
    internal class Video1
    {
        private static void Foo()
        {
            Console.WriteLine("Foo");
        }
        private static void Goo()
        {
            Console.WriteLine("Goo");
        }
        private delegate void MyDelegate();
        public static void TestMain()
        {
            MyDelegate mydelg = new(Foo);
            mydelg();
            mydelg();
            Console.WriteLine("");
            mydelg += Goo;
            mydelg();
            mydelg();
            mydelg -= Foo;
            Console.WriteLine("");
            mydelg();
            mydelg();
        }
    }
}
