using Kanoodle.Core;
using System;
using System.Collections.Generic;

namespace Kanoodle.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KANOODLE!");
            var escape = false;
            while (!escape)
            {
                Console.WriteLine("Choose and option: (S)olutions, (P)ieces, (I)nfo, (B)uilder, (E)xit");
                var module = Console.ReadLine();

                if (module == "S") // view game solutions
                {
                    var solver = new Solver();
                    solver.ViewSolution();
                }
                if (module == "B") // build a board state with the option to solve it
                {
                    var builder = new Builder();
                    var state = builder.Build();

                    if (state != null)
                    {
                        var solver = new Solver();
                        solver.Solve(state);
                    }
                }
                else if (module == "P") // browse piece positions
                {
                    var browser = new Browser();
                    browser.Browse();
                }
                else if (module == "I") // browse piece info
                {
                    var browser = new Browser();
                    browser.Info();
                }
                else if (module == "E") // quit
                {
                    escape = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                }
            }

        } // main
    }
}
