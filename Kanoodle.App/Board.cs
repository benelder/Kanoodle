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
        private List<char> PiecesUsed { get; set; }
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
                .Where(m => !PiecesUsed.Contains(m.Key))
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
            PiecesUsed = new List<char>();
            UsedLocations = new HashSet<Location>();
        }

        public bool IsPieceUsed(string key)
        {
            return PiecesUsed.Contains(char.Parse(key));
        }

        public IEnumerable<KeyValuePair<char, List<Piece>>> GetUnusedColors()
        {
            return PieceRegistry.Colors.Where(m => !PiecesUsed.Contains(m.Key));
        }

        public void Print()
        {
            for (int g = 5; g >= 0; g--)
            {
                for (int b = 5; b >= 0; b--)
                {
                    var toPrint = "    ";

                    for (int i = 0; i < b; i++)
                    {
                        toPrint += " ";
                    }

                    for (int i = 0; i < g; i++)
                    {
                        toPrint += " ";
                    }

                    for (int a = 0; a < 6; a++)
                    {
                        toPrint += BoardMap[a, b, g].FormatForBoardPrint() + " ";
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
                    var mapNode = BoardMap[abs[i].Offset.A, abs[i].Offset.B, abs[i].Offset.G];
                    if (mapNode != '-')
                        throw new Exception("Attempt to add piece in used location");

                    BoardMap[abs[i].Offset.A, abs[i].Offset.B, abs[i].Offset.G] = piece.Character;
                    UsedLocations.Add(abs[i].Offset);
                }
                PiecesUsed.Add(piece.Character);
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
                BoardMap[abs[i].Offset.A, abs[i].Offset.B, abs[i].Offset.G] = '-';
                UsedLocations.Remove(abs[i].Offset);
            }
            PiecesUsed.Remove(piece.Character);
        }

        public bool LoadGame(int gameNum)
        {
            try
            {
                var game = GameFactory.Games[gameNum];

                foreach (var piece in game)
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
                var mapNode = BoardMap[abs[i].Offset.A, abs[i].Offset.B, abs[i].Offset.G];
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
