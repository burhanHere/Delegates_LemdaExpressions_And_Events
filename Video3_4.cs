using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_LemdaExpressions_And_Events
{
    internal class Video3_4
    {
        private bool LessThen10(int number) => number < 10;
        private bool LessThen5(int number) => number < 5;
        private bool LessThen3(int number) => number < 3;
        private bool GraterThen7(int number) => number > 7;

        private delegate bool pipeLine(int number);

        private void pipeLineFunction(IEnumerable<int> input, pipeLine MyPipeLine)
        {
            foreach (var item in input)
            {
                if (MyPipeLine(item))
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine("\n______________________________________________");
            foreach (var item in MyPipeLine.GetInvocationList())
            {
                Console.WriteLine(item.Target + ": " + item.Method);
            }
            Console.WriteLine("");


        }
        public static void TestMain()
        {
            var obj = new Video3_4();

            List<int> numbers = [52, 5, 54, 5, 6, 2, 45, 854, 58, 3, 13, 15, 545, 1, 1, 6515, 1, 65, 651, 5];
            Console.Write("Gratter then 7: "); obj.pipeLineFunction(numbers, obj.GraterThen7);
            Console.Write("Less then 5: "); obj.pipeLineFunction(numbers, obj.LessThen5);
            Console.Write("Less then 3: "); obj.pipeLineFunction(numbers, obj.LessThen3);
            Console.Write("Less then 10: "); obj.pipeLineFunction(numbers, obj.LessThen10);

            Console.WriteLine("Perfroming above code with lembda expressions:");
            Console.Write("Gratter then 7: "); obj.pipeLineFunction(numbers, number => number > 7);
            Console.Write("Less then 5: "); obj.pipeLineFunction(numbers, number => number < 5);
            Console.Write("Less then 3: "); obj.pipeLineFunction(numbers, number => number < 3);
            Console.Write("Less then 10: "); obj.pipeLineFunction(numbers, number => number < 10);
        }
    }
}
