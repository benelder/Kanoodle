using Kanoodle.Core;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanoodle.App
{
    public class Board
    {

        public HashSet<Location> UsedLocations { get; set; }
        public Dictionary<char, Piece> PiecesUsed { get; set; }
        private char[,,] BoardMap { get; set; }
        public PieceRegistry PieceRegistry { get; set; }

        public Board()
        {
            InitializeBoard();
            UsedLocations = new HashSet<Location>();
            PieceRegistry = new PieceRegistry();
        }

        public ulong GetTotalPositionCount()
        {
            return PieceRegistry.Colors
                .Where(m => !PiecesUsed.ContainsKey(m.Key))
                .Aggregate((ulong)1, (x, y) => x * (ulong)y.Value.Count());
        }

        private void InitializeBoard()
        {
            BoardMap = new char[6, 6, 6];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (i + j + k < 6)
                            BoardMap[i, j, k] = '-';
                        else
                            BoardMap[i, j, k] = ' ';
                    }
                }
            }
            PiecesUsed = new Dictionary<char, Piece>();
            UsedLocations = new HashSet<Location>();
        }

        public bool IsPieceUsed(string key)
        {
            return PiecesUsed.ContainsKey(char.Parse(key));
        }

        public IEnumerable<KeyValuePair<char, List<Piece>>> GetUnusedColors()
        {
            return PieceRegistry.Colors.Where(m => !PiecesUsed.ContainsKey(m.Key));
        }

        public void Print()
        {
            for (int z = 5; z >= 0; z--)
            {
                for (int y = 5; y >= 0; y--)
                {
                    var toPrint = "    ";

                    for (int i = 0; i < y; i++)
                    {
                        toPrint += " ";
                    }

                    for (int i = 0; i < z; i++)
                    {
                        toPrint += " ";
                    }

                    for (int x = 0; x < 6; x++)
                    {
                        toPrint += BoardMap[x, y, z].FormatForBoardPrint() + " ";
                    }

                    if (!string.IsNullOrWhiteSpace(toPrint.Trim())) AnsiConsole.MarkupLine(toPrint);
                }
                Console.WriteLine();
            }
        }

        public void PlacePiece(Piece piece)
        {
            try
            {
                var abs = piece.GetAbsolutePosition();
                for (int i = 0; i < abs.Length; i++)
                {
                    var mapNode = BoardMap[abs[i].Offset.X, abs[i].Offset.Y, abs[i].Offset.Z];
                    if (mapNode != '-')
                        throw new Exception("Attempt to add piece in used location");

                    BoardMap[abs[i].Offset.X, abs[i].Offset.Y, abs[i].Offset.Z] = piece.Character;
                    UsedLocations.Add(abs[i].Offset);
                }
                PiecesUsed.Add(piece.Character, piece);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error placing {piece.Name}");
                RemovePiece(piece);
                throw;
            }
        }

        public void RemovePiece(Piece piece)
        {
            var abs = piece.GetAbsolutePosition();
            for (int i = 0; i < abs.Length; i++)
            {
                BoardMap[abs[i].Offset.X, abs[i].Offset.Y, abs[i].Offset.Z] = '-';
                UsedLocations.Remove(abs[i].Offset);
            }
            PiecesUsed.Remove(piece.Character);
        }

        public bool LoadGame(string gameNum)
        {
            try
            {
                var game = GameFactory.Games[gameNum];

                foreach (var piece in game.State)
                {
                    PlacePiece(piece);
                }

                return true;
            }
            catch (Exception)
            {
                Clear();
                return false;
            }
        }

        public bool LoadSolution(string gameNum)
        {
            try
            {
                var game = GameFactory.Games[gameNum];

                foreach (var piece in game.Solution)
                {
                    PlacePiece(piece);
                }

                return true;
            }
            catch (Exception)
            {
                Clear();
                return false;
            }
        }

        public void Clear()
        {
            InitializeBoard();
        }

        public bool Collision(Piece piece)
        {
            var abs = piece.GetAbsolutePosition();
            var toRet = false;
            for (int i = 0; i < abs.Length; i++)
            {
                var mapNode = BoardMap[abs[i].Offset.X, abs[i].Offset.Y, abs[i].Offset.Z];
                if (mapNode != '-')
                {
                    toRet = true;
                    break;
                }
            }
            return toRet;
        }

        
    }
}
