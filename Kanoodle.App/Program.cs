using Kanoodle.Core;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Kanoodle.App
{
    class Program
    {
        public static Dictionary<char, List<Piece>> Colors { get; set; }
        public static List<Piece> RedPositions { get; set; }
        public static List<Piece> PinkPositions { get; set; }
        public static List<Piece> LimePositions { get; set; }
        public static List<Piece> DarkBluePositions { get; set; }
        public static List<Piece> LightBluePositions { get; set; }
        public static List<Piece> GreenPositions { get; set; }
        public static List<Piece> YellowPositions { get; set; }
        public static List<Piece> PurplePositions { get; set; }
        public static List<Piece> PeachPositions { get; set; }
        public static List<Piece> GrayPositions { get; set; }
        public static List<Piece> OrangePositions { get; set; }
        public static List<Piece> WhitePositions { get; set; }
        public static HashSet<Location> UsedLocations { get; set; }
        public static List<char> PiecesUsed { get; set; }
        public static List<Piece> PositionsUsed { get; set; }
        public static char[,,] BoardMap { get; set; }
        public static int PositionCount { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("KANOODLE!");
            var escape = false;
            while (!escape)
            {
                Console.WriteLine("Choose and option: (S)olver, (P)ieces, (B)uilder, (E)xit");
                var module = Console.ReadLine();

                if (module == "S")
                {
                    var solver = new Solver();
                    solver.Solve();
                }
                if (module == "B")
                {
                    var builder = new Builder();
                    var state = builder.Build();

                    if(state != null)
                    {
                        var solver = new Solver();
                        solver.Solve(state);
                    }
                }
                else if (module == "P")
                {
                    var browser = new Browser();
                    browser.Browse();
                }
                else if (module == "E")
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
