using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_LemdaExpressions_And_Events
{
    class EnrolledEventArgs : EventArgs
    {
        public short rollNo { get; set; }
    }

    partial class Student : EnrolledEventArgs
    {


        public delegate void EnrolledEventHandler(object sender, EnrolledEventArgs args);
        public event EnrolledEventHandler? Enrolled;
        public void Enroll(short stuidentID)
        {

            for (int i = 0; i < 3; i++)
            {
                // do some long running process on another service, another machine, somewhere else
                Thread.Sleep(1000);
            }
            Enrolled?.Invoke(this,
                new EnrolledEventArgs
                {
                    rollNo = stuidentID
                });

        }

    }
    partial class Student
    {
        public void Foo(object sender, EnrolledEventArgs args)
        {
            Console.WriteLine($"Do some thing else with {args.rollNo}.");
        }
    }
    internal class EventsWithDelegates : Student
    {
        public static void TestMain()
        {
            var s = new Student();
            s.Enrolled += (sender, args) => Console.WriteLine("I'm now enrolled for the year ");
            s.Enrolled += s.Foo;
            s.Enroll(1059);
            Thread.Sleep(2000);
            s.Enrolled -= (sender, args) => Console.WriteLine("I'm now enrolled for the year ");
            s.Enroll(0485);
        }
    }
}
