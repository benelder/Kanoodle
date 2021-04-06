using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static List<Piece> Board { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("CANOODLE!");

            var pieces = new Piece[]
            {
                new Lime(),
                new Green(),
                new DarkBlue(),
                new Pink(),
                new LightBlue(),
                new Orange(),
                new White(),
                new Yellow(),
                new Peach(),
                new Purple(),
                new Gray(),
                new Red()
            };



            for (int a = 0; a < 6; a++)
            {
                for (int b = 0; b < 6; b++)
                {
                    for (int g = 0; g < 6; g++)
                    {
                        Console.WriteLine("Attempting to place pieces at location {0}, {1}, {2}", a, b, g);
                        foreach (var piece in pieces)
                        {
                            var piecePlaced = false;

                            for (int rg = 0; rg < 6; rg++)
                            {
                                for (int ra = 0; ra < 3; ra++)
                                {
                                    for (int rb = 0; rb < 3; rb++)
                                    {
                                        Console.WriteLine("Attempting to place {0} at location {1}, {2}, {3} with rotation {4}, {5}, {6}", piece.Name, a, b, g, ra, rb, rg);

                                        piece.RootPosition = new Location(a, b, g);
                                        piece.ARotation = ra;
                                        piece.BRotation = rb;
                                        piece.GRotation = rg;

                                        var abs = piece.GetAbsolutePosition();

                                        var absString = "";
                                        for (int i = 0; i < abs.Length; i++)
                                        {
                                            if (i == 0)
                                                absString = abs[0].ToString();
                                            else
                                            {
                                                var node = abs[i];
                                                absString += $", {abs[i]}";
                                            }
                                        }

                                        var isInBounds = !piece.IsOutOfBounds();
                                        Console.WriteLine("Absolute position is: {0}; InBounds = {1}", absString, isInBounds.ToString().ToUpper());

                                        if (isInBounds)
                                        {
                                            Console.WriteLine($"Leaving {piece.Name} piece in place");
                                            Board.Add(piece);
                                        }

                                        if (piecePlaced) break;
                                    }

                                    if (piecePlaced) break;
                                }

                                if (piecePlaced) break;
                            }
                        }
                    } 
                }
            }
        } // main

        public string PrintBoard()
        {
            var toRet = "";

            for (int i = 0; i < Board.Count; i++)
            {
                if (i == 0)
                    toRet += $"{{{Board[0].Name} : {Board[0].RootPosition}}}";

                else
                    toRet += $", {{{Board[0].Name} : {Board[0].RootPosition}}}";
            }

            return toRet;
        }
    }
}
