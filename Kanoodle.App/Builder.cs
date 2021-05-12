using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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
            }

            Console.WriteLine("Final board initialized state:");
            for (int i = 0; i < PositionsUsed.Count(); i++)
            {
                var piece = PositionsUsed.ElementAt(i);
                Console.WriteLine(piece);
            }

            var showCode = false;
            while (!showCode)
            {
                Console.WriteLine("Would you like to generate code to add this build to the solution? (Y)es, (N)o");
                var result = Console.ReadLine();
                if (result == "Y")
                {
                    GenerateCode();
                    showCode = true;
                }
                else if (result == "N")
                {
                    showCode = true;
                }
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

        private void GenerateCode(Piece piece)
        {
            var varName = piece.Character.ToString().ToLower();

            Console.WriteLine($"    var {varName} = new {GetColorName(piece.Character)}().Shapes.ElementAt(0);");
            Console.WriteLine($"    {varName}.RootPosition = new Location({piece.RootPosition.A}, {piece.RootPosition.B}, {piece.RootPosition.G});");
            Console.WriteLine($"    {varName}.ARotation = {piece.ARotation};");
            Console.WriteLine($"    {varName}.BRotation = {piece.BRotation};");
            Console.WriteLine($"    {varName}.GRotation = {piece.GRotation};");
            Console.WriteLine($"    toRet.Add({varName});");
            Console.WriteLine();
        }

        private void GenerateCode()
        {
            Console.WriteLine("public static IEnumerable<Piece> GameX()");
            Console.WriteLine("{");
            Console.WriteLine("    var toRet = new List<Piece>();");
            Console.WriteLine();

            for (int i = 0; i < PositionsUsed.Count(); i++)
            {
                GenerateCode(PositionsUsed[i]);
            }

            Console.WriteLine("    return toRet;");
            Console.WriteLine("}");
            Console.WriteLine();
        }

        private string GetColorName(char c)
        {
            switch (c)
            {
                case 'A': return "Lime";
                case 'B': return "Yellow";
                case 'C': return "DarkBlue";
                case 'D': return "LightBlue";
                case 'E': return "Red";
                case 'F': return "Pink";
                case 'G': return "Green";
                case 'H': return "White";
                case 'I': return "Orange";
                case 'J': return "Peach";
                case 'K': return "Gray";
                case 'L': return "Purple";
                default: throw new Exception("Invlaid color char");
            }
        }

        private void SelectPosition(char color)
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
                            var positions = Board.Colors[color]
                                .Where(m => m.GetAbsolutePosition().Any(n => n.Offset.A == a && n.Offset.B == b && n.Offset.G == g) &&
                                m.GetAbsolutePosition().All(m => !Board.UsedLocations.Contains(m.Offset)))
                                .ToArray();
                            var result = CycleThroughPositions(positions);
                            success = result;
                            escape = result;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid coordinates. Please try again");
                        }
                    }
                }

                if (selection == "A") // cycle through ALL possible positions
                {
                    var positions = Board.Colors[color].Where(m => m.GetAbsolutePosition().All(m => !Board.UsedLocations.Contains(m.Offset))).ToArray();
                    var result = CycleThroughPositions(positions);
                    escape = result;
                }
            }
        }

        private bool CycleThroughPositions(IEnumerable<Piece> positions)
        {
            var total = positions.Count();
            var toRet = false;

            for (int i = 0; i < total; i++)
            {
                var item = positions.ElementAt(i);
                Board.Clear();
                AddSelectedPiecesToBoard();
                Board.PlacePiece(item);
                Board.Print();
                Console.WriteLine("Position {1} of {2}", item.Name, i + 1, total);
                Console.WriteLine("{0} @ Root:{1} Ar:{2} Br:{3} Gr:{4}", item.Name, item.RootPosition, item.ARotation, item.BRotation, item.GRotation);
                Console.WriteLine("Press SPACE to select this piece position");
                var next = Console.ReadKey();
                if (next.Key == ConsoleKey.Spacebar)
                {
                    PositionsUsed.Add(item);
                    toRet = true;
                    break;
                }
                else if (next.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (next.Key == ConsoleKey.LeftArrow)
                {
                    if (i == 0)
                        i = total - 2;
                    else
                        i -= 2;
                }
                else if (next.Key == ConsoleKey.RightArrow)
                {
                    if (i == total - 1)
                        i = -1;
                }
            }

            return toRet;
        }

        private void AddSelectedPiecesToBoard()
        {
            foreach (var item in PositionsUsed)
            {
                Board.PlacePiece(item);
            }
        }
    }
}
