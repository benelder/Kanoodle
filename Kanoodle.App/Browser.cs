using System;
using System.Collections.Generic;
using Kanoodle.Core;
using System.Linq;

namespace Kanoodle.App
{
    public class Browser
    {
        public Board Board { get; set; }

        public Browser()
        {
            Board = new Board();
        }

        public void Info()
        {
            Console.WriteLine("Statistics for valid shape configurations");
            Board.PieceRegistry.WriteShapeStats();
        }

        public void Browse()
        {
            var escape = false;

            while (!escape)
            {
                Console.WriteLine("Select a color char A-L, or Q to exit");
                var module = Console.ReadLine();

                if (module == "Q")
                {
                    escape = true;
                    continue;
                }


                DisplayPositions(char.Parse(module));
            }
        }

        private void DisplayPositions(char module)
        {
            var escape = false;

            while (!escape)
            {
                Console.WriteLine("(F)ilter by location or (A)ll; (Q) to exit");
                var selection = Console.ReadLine();

                if (selection == "Q")
                {
                    escape = true;
                    continue;
                }

                if (selection == "F")
                {
                    var success = false;
                    while (!success)
                    {
                        try
                        {
                            Console.WriteLine("Filter to positions that include a specific location. Enter the three-digit position as ABG or Q to quit");
                            var coords = Console.ReadLine();

                            if (coords == "Q")
                                break;

                            var x = int.Parse(coords[0].ToString());
                            var y = int.Parse(coords[1].ToString());
                            var z = int.Parse(coords[2].ToString());
                            var positions = Board.PieceRegistry.Colors[module].Where(m => m.GetAbsolutePosition().Any(n => n.Offset.X == x && n.Offset.Y == y && n.Offset.Z == z)).ToArray();
                            
                            BrowseThroughPositions(positions);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid coordinates. Please try again");
                        }
                    }
                }

                if (selection == "A") // cycle through ALL possible positions
                {
                    var positions = Board.PieceRegistry.Colors[module];
                    BrowseThroughPositions(positions);
                }
            }
        }

        private void BrowseThroughPositions(IEnumerable<Piece> positions)
        {
            var total = positions.Count();

            for (int i = 0; i < total; i++)
            {
                var item = positions.ElementAt(i);
                Board.Clear();
                Board.PlacePiece(item);
                Board.Print();
                Console.WriteLine("Position {1} of {2}", item.Name, i, total);
                Console.WriteLine("{0} @ Root:{1} Plane:{2} Rotation:{3} Lean:{4}", item.Name, item.RootPosition, item.Plane, item.Rotation, item.Lean);
                var next = Console.ReadKey();
                if (next.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (next.Key == ConsoleKey.LeftArrow)
                {
                    if (i > 0)
                        i -= 2;
                }
            }
        }
    }

   
}
