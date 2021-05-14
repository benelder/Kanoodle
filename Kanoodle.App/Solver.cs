﻿using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Kanoodle.App
{
    public class Solver
    {
        public Board Board { get; set; }
        public int PositionCount { get; set; }

        public void Solve()
        {
            Solve(null);
        }

        public void Solve(IEnumerable<Piece> state)
        {
            Board = new Board();

            if (state != null)
            {
                // load state
                LoadState(state);
            }
            else
            {
                SelectAndLoadGame();
            }

            Console.WriteLine("Board loaded. Initial setup looks like this");

            Board.Print();

            var totalPositionCount = Board.GetTotalPositionCount();
            Console.WriteLine("There are {0} total position combinations possible in this game", totalPositionCount.ToString("N0"));

            GetSolveInput();

            Console.ReadLine();
        }

        private void GetSolveInput()
        {
            var escape = false;

            while (!escape)
            {
                Console.WriteLine("(C)ount all possible solutions. or (S)olve");

                var response = Console.ReadLine();

                if(response == "S")
                {
                    AttemptToSolve();
                    escape = true;
                }
                else if(response == "C")
                {
                    CountPossibleSolutions();
                    escape = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        private void CountPossibleSolutions()
        {
            var timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Attempting to place pieces");

            _solutionCount = 0;
            CountSolutions();

            if (_solutionCount > 0)
            {
                timer.Stop();
                Console.WriteLine($"Total of {_solutionCount} possible solutions found!");
                Console.WriteLine("Time elapsed: {0}", timer.Elapsed);
            }
            else
            {
                timer.Stop();
                Console.WriteLine("It appears that this is an unsolvable state");
            }
        }

        private void AttemptToSolve()
        {
            var timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Attempting to place pieces");

            var solutionFound = PlacePieces();

            if (solutionFound)
            {
                timer.Stop();
                Board.Print();
                Console.WriteLine("SOLUTION FOUND!!");
                Console.WriteLine("Time elapsed: {0}", timer.Elapsed);
                Console.WriteLine("Piece positions tried: {0}", PositionCount.ToString("N0"));
            }
            else
            {
                Console.WriteLine("It appears that this is an unsolvable state");
            }
        }

        private void SelectAndLoadGame()
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

                gameLoaded = Board.LoadGame(gameNum);

                if (!gameLoaded)
                {
                    Console.WriteLine("That game is not in the catalog. Please try a different number");
                    continue;
                }

                gameLoaded = true;
            }
        }

        private bool LoadState(IEnumerable<Piece> state)
        {
            try
            {
                foreach (var piece in state)
                {
                    Board.PlacePiece(piece);
                }

                return true;
            }
            catch (Exception)
            {
                Board.Clear();
                return false;
            }
        }

        private bool PlacePieces()
        {
            var unusedColors = Board.GetUnusedColors();
            
            if (unusedColors.Count() == 0) // all pieces have been placed! We've solved it!
            {
                return true;
            }

            // take next unused color ensuring it doesn't collide with a taken position
            var pieces = unusedColors.First().Value
                .Where(s => s.GetAbsolutePosition().All(m => !Board.UsedLocations.Contains(m.Offset)))
                .ToArray(); 

            foreach (var position in pieces)
            {
                PositionCount++; // increment counter of position attempts

                if (!Board.Collision(position)) // if piece fits onto board
                {
                    Board.PlacePiece(position); 
                    var s = PlacePieces(); // recurse
                    if (s) return true;
                    Board.RemovePiece(position); // remove piece from board and loop to try next position
                }
            }

            return false; // we've exhausted all possible positions for this color without finding a solution
        }

        private int _solutionCount = 0;
        private bool CountSolutions()
        {
            var unusedColors = Board.GetUnusedColors();
            
            if (unusedColors.Count() == 0) // all pieces have been placed! We've solved it!
            {
                _solutionCount++;
                Console.WriteLine($"SOLUTION {_solutionCount} FOUND");
                Board.Print();
                return true;
            }

            var pieces = unusedColors.First().Value; // take next unused color

            foreach (var position in pieces)
            {
                PositionCount++; // increment counter of position attempts

                if (!Board.Collision(position)) // if piece fits onto board
                {
                    Board.PlacePiece(position);
                    CountSolutions(); // recurse
                    Board.RemovePiece(position); // remove piece from board and loop to try next position
                }
            }

            return false; // we've exhausted all possible positions for this color without finding a solution
        }
    }
}
