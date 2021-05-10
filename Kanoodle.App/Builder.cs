using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanoodle.App
{
    public class Builder
    {
        public List<Piece> PositionsUsed { get; set; }
        public Board Board { get; set; }

        public Builder()
        {
            Board = new Board();
            PositionsUsed = new List<Piece>();
        }

        public List<Piece> Build()
        {
            var escape = false;

            while (!escape)
            {
                Console.WriteLine("Select a color A-L to place a piece on the board, or Q to exit");
                var module = Console.ReadLine();

                if (module == "Q")
                {
                    escape = true;
                    continue;
                }

                if (Board.IsPieceUsed(module))
                {
                    Console.WriteLine("That piece is already in use");
                    continue;
                }

                SelectPosition(char.Parse(module));

                Board.Print();
            }

            Console.WriteLine("Final board initialized state:");
            for (int i = 0; i < PositionsUsed.Count(); i++)
            {
                var piece = PositionsUsed.ElementAt(i);
                Console.WriteLine(piece);
            }

            var validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Do you want to solve this puzzle state? (Y)es, (N)o");
                var result = Console.ReadLine();

                if (result == "Y")
                {
                    return PositionsUsed;
                }
                else if (result == "N")
                {
                    return null;
                }
            }

            return null;
        }

        private void SelectPosition(char module)
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

                            var a = int.Parse(coords[0].ToString());
                            var b = int.Parse(coords[1].ToString());
                            var g = int.Parse(coords[2].ToString());
                            var positions = Board.Colors[module].Where(m => m.GetAbsolutePosition().Any(n => n.Offset.A == a && n.Offset.B == b && n.Offset.G == g)).ToArray();
                            var total = positions.Count();

                            for (int i = 0; i < total; i++)
                            {
                                var item = positions[i];
                                Board.Clear();
                                Board.PlacePiece(item);
                                Board.Print();
                                Console.WriteLine("Position {1} of {2}", item.Name, i, total);
                                Console.WriteLine("{0} @ Root:{1} Ar:{2} Br:{3} Gr:{4}", item.Name, item.RootPosition, item.ARotation, item.BRotation, item.GRotation);
                                Console.WriteLine("Press SPACE to select this piece position");
                                var next = Console.ReadKey();
                                if (next.Key == ConsoleKey.Spacebar)
                                {
                                    PositionsUsed.Add(item);
                                    success = true;
                                    escape = true;
                                    break;
                                }
                                if (next.Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else if (next.Key == ConsoleKey.LeftArrow)
                                {
                                    if (i > 1)
                                        i -= 2;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid coordinates. Please try again");
                        }
                    }
                }

                if (selection == "A") // cycle through ALL possible positions
                {
                    var positions = Board.Colors[module];
                    var total = positions.Count();

                    for (int i = 0; i < total; i++)
                    {
                        var item = positions[i];
                        Board.Clear();
                        Board.PlacePiece(item);
                        Board.Print();
                        Console.WriteLine("Position {1} of {2}", item.Name, i, total);
                        Console.WriteLine("{0} @ Root:{1} Ar:{2} Br:{3} Gr:{4}", item.Name, item.RootPosition, item.ARotation, item.BRotation, item.GRotation);
                        Console.WriteLine("Press SPACE to select this piece position");
                        var next = Console.ReadKey();
                        if (next.Key == ConsoleKey.Spacebar)
                        {
                            PositionsUsed.Add(item);
                            escape = true;
                            break;
                        }
                        if (next.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else if (next.Key == ConsoleKey.LeftArrow)
                        {
                            if (i > 1)
                                i -= 2;
                        }
                    }
                }
            }
        }
    }
}
