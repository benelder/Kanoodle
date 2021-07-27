﻿using Kanoodle.Core;
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
            LoadInitialState();

            ChoosePieces();

            DisplayFinalBoardState();

            RequestCodeGenInput();

            return RequestSolverInput();

        }

        private void LoadInitialState()
        {
            var escape = false;

            while (!escape)
            {
                Console.WriteLine("(L)oad initial game state, or start with (E)mpty board?");
                var state = Console.ReadLine();

                if (state == "L")
                {

                    var gameLoaded = false;

                    while (!gameLoaded)
                    {
                        foreach (var item in GameFactory.Games)
                        {
                            Console.WriteLine(item.Key);
                        }

                        Console.WriteLine("Select a game number from the list to load a game");

                        var gameNumStr = Console.ReadLine();

                        var isNum = int.TryParse(gameNumStr, out int gameNum);

                        if (!isNum)
                        {
                            Console.WriteLine("Not a number");
                            continue;
                        }

                        try
                        {
                            var game = GameFactory.Games[gameNum];

                            foreach (var piece in game)
                            {
                                PositionsUsed.Add(piece);
                                Board.PlacePiece(piece);
                            }
                            gameLoaded = true;

                        }
                        catch (Exception)
                        {
                            gameLoaded = false;
                        }
                        

                        if (!gameLoaded)
                        {
                            Console.WriteLine("That game is not in the catalog. Please try a different number");
                            continue;
                        }
                    }

                    escape = true;
                }
                else if (state == "E")
                {
                    escape = true;
                }
            }
        }

        private void ChoosePieces()
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
        }

        private void DisplayFinalBoardState()
        {
            Console.WriteLine("Final board initialized state:");
            for (int i = 0; i < PositionsUsed.Count(); i++)
            {
                var piece = PositionsUsed.ElementAt(i);
                Console.WriteLine(piece);
            }
        }

        private void RequestCodeGenInput()
        {
            var showCode = false;
            while (!showCode)
            {
                Console.WriteLine("Would you like to generate code to add this build to the solution? (Y)es, (N)o");
                var result = Console.ReadLine();
                if (result == "Y")
                {
                    var codeGen = new CodeGenerator();
                    codeGen.GenerateCode(PositionsUsed);
                    showCode = true;
                }
                else if (result == "N")
                {
                    showCode = true;
                }
            }
        }

        private List<Piece> RequestSolverInput()
        {
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
                            Console.WriteLine("Filter to positions that include a specific location. Enter the three-digit position as XYZ or Q to quit");
                            var coords = Console.ReadLine();

                            if (coords == "Q")
                                break;

                            var x = int.Parse(coords[0].ToString());
                            var y = int.Parse(coords[1].ToString());
                            var z = int.Parse(coords[2].ToString());
                            var positions = Board.PieceRegistry.Colors[color]
                                .Where(m => m.GetAbsolutePosition().Any(n => n.Offset.X == x && n.Offset.Y == y && n.Offset.Z == z) &&
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
                    var positions = Board.PieceRegistry.Colors[color].Where(m => m.GetAbsolutePosition().All(m => !Board.UsedLocations.Contains(m.Offset))).ToArray();
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
                Console.WriteLine("{0} @ Root:{1} Plane:{2} Rotation:{3} Lean:{4}", item.Name, item.RootPosition, item.Plane, item.Rotation, item.Lean);
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
