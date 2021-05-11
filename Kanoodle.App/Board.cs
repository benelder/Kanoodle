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
        private Dictionary<int, IEnumerable<Piece>> _games;
        public Dictionary<int, IEnumerable<Piece>> Games
        {
            get
            {

                if (_games == null)
                {
                    _games = new Dictionary<int, IEnumerable<Piece>>();

                    _games.Add(44, GameFactory.Game44());
                    _games.Add(45, GameFactory.Game45());
                    _games.Add(89, GameFactory.Game89());
                    _games.Add(95, GameFactory.Game95());
                    _games.Add(96, GameFactory.Game96());
                    _games.Add(99, GameFactory.Game99());
                    _games.Add(100, GameFactory.Game100());
                    _games.Add(201, GameFactory.Game201());
                    _games.Add(202, GameFactory.Game202());
                    _games.Add(203, GameFactory.Game203());
                    _games.Add(204, GameFactory.Game204());
                }

                return _games;
            }
        }

        public Dictionary<char, List<Piece>> Colors { get; set; }
        private List<Piece> RedPositions { get; set; }
        private List<Piece> PinkPositions { get; set; }
        private List<Piece> LimePositions { get; set; }
        private List<Piece> DarkBluePositions { get; set; }
        private List<Piece> LightBluePositions { get; set; }
        private List<Piece> GreenPositions { get; set; }
        private List<Piece> YellowPositions { get; set; }
        private List<Piece> PurplePositions { get; set; }
        private List<Piece> PeachPositions { get; set; }
        private List<Piece> GrayPositions { get; set; }
        private List<Piece> OrangePositions { get; set; }
        private List<Piece> WhitePositions { get; set; }
        private HashSet<Location> UsedLocations { get; set; }
        private List<char> PiecesUsed { get; set; }
        private char[,,] BoardMap { get; set; }

        public Board()
        {
            InitializeBoard();
            UsedLocations = new HashSet<Location>();
            LoadPossiblePositions2();
            InitializeColors();
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
        }

        private int _totalPositionsTested = 0;

        private void LoadPossiblePositions2()
        {
            RedPositions = LoadPositionsForColor<Red>();
            PinkPositions = LoadPositionsForColor<Pink>();
            PurplePositions = LoadPositionsForColor<Purple>();
            DarkBluePositions = LoadPositionsForColor<DarkBlue>(); ;
            LightBluePositions = LoadPositionsForColor<LightBlue>(); ;
            WhitePositions = LoadPositionsForColor<White>(); ;
            GrayPositions = LoadPositionsForColor<Gray>(); ;
            LimePositions = LoadPositionsForColor<Lime>(); ;
            OrangePositions = LoadPositionsForColor<Orange>(); ;
            PeachPositions = LoadPositionsForColor<Peach>(); ;
            YellowPositions = LoadPositionsForColor<Yellow>(); ;
            GreenPositions = LoadPositionsForColor<Green>(); ;

            Console.WriteLine("All possible positions initialized.");
            Console.WriteLine("Total of {0} positions tested.", _totalPositionsTested);
            Console.WriteLine("Total of {0} positions registered as valid.",
                LimePositions.Count +
                YellowPositions.Count +
                DarkBluePositions.Count +
                LightBluePositions.Count +
                RedPositions.Count +
                PinkPositions.Count +
                GreenPositions.Count +
                WhitePositions.Count +
                OrangePositions.Count +
                PeachPositions.Count +
                GrayPositions.Count +
                PurplePositions.Count);
        }

        private List<Piece> LoadPositionsForColor<T>() where T : Core.Color, new()
        {
            var red = new T();
            var toRet = new List<Piece>();

            for (int i = 0; i < red.Shapes.Count(); i++)
            {
                for (int g = 0; g < 6; g++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        for (int a = 0; a < 6; a++)
                        {
                            if (a + b + g > 5) // will be out of bounds
                                continue;

                            for (int rg = 0; rg < 6; rg++)
                            {
                                // B rotations
                                for (int rb = 0; rb < 3; rb++)
                                {
                                    if (rb == 1 && rg == 1) continue; // incompatible transformation

                                    _totalPositionsTested++;
                                    red = new T();
                                    var shape = red.Shapes.ElementAt(i);

                                    shape.RootPosition = new Location(a, b, g);

                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (shape.IsOutOfBounds())
                                        continue;

                                    if (shape.GetAbsolutePosition().Any(m => UsedLocations.Contains(m.Offset)))
                                        continue;

                                    if (toRet.Any(m => m.IsInSamePositionAs(shape)))
                                        continue;

                                    toRet.Add(shape);
                                }

                                // A rotations
                                for (int ra = 1; ra < 3; ra++) // ra starts at 1 because zero was already accounted for in the B rotation loop above
                                {

                                    _totalPositionsTested++;
                                    red = new T();
                                    var shape = red.Shapes.ElementAt(i);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (shape.IsOutOfBounds())
                                        continue;

                                    if (shape.GetAbsolutePosition().Any(m => UsedLocations.Contains(m.Offset)))
                                        continue;

                                    if (toRet.Any(m => m.IsInSamePositionAs(shape)))
                                        continue;

                                    toRet.Add(shape);
                                }
                            }
                        }
                    }
                }
            }

            return toRet;
        }


        private void InitializeColors()
        {
            Colors = new Dictionary<char, List<Piece>>()
            {
                { 'A', LimePositions },
                { 'B', YellowPositions },
                { 'C', DarkBluePositions },
                { 'D', LightBluePositions },
                { 'E', RedPositions },
                { 'F', PinkPositions },
                { 'G', GreenPositions },
                { 'H', WhitePositions },
                { 'I', OrangePositions },
                { 'J', PeachPositions },
                { 'K', GrayPositions },
                { 'L', PurplePositions },
            };
        }

        public bool IsPieceUsed(string key)
        {
            return PiecesUsed.Contains(char.Parse(key));
        }

        public IEnumerable<KeyValuePair<char, List<Piece>>> GetUnusedColors()
        {
            return Colors.Where(m => !PiecesUsed.Contains(m.Key));
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
                        toPrint += FormatPiece(BoardMap[a, b, g]) + " ";
                    }

                    if (!string.IsNullOrWhiteSpace(toPrint.Trim())) AnsiConsole.MarkupLine(toPrint);
                }
                Console.WriteLine();
            }
        }

        private string FormatPiece(char v)
        {
            switch (v)
            {
                case 'A':
                    return $"[bold palegreen3]{v}[/]";
                case 'B':
                    return $"[bold yellow]{v}[/]";
                case 'C':
                    return $"[bold blue1]{v}[/]";
                case 'D':
                    return $"[bold steelblue1]{v}[/]";
                case 'E':
                    return $"[bold red]{v}[/]";
                case 'F':
                    return $"[bold fuchsia]{v}[/]";
                case 'G':
                    return $"[bold darkgreen]{v}[/]";
                case 'H':
                    return $"[bold white]{v}[/]";
                case 'I':
                    return $"[bold darkorange]{v}[/]";
                case 'J':
                    return $"[bold lightpink1]{v}[/]";
                case 'K':
                    return $"[bold grey70]{v}[/]";
                case 'L':
                    return $"[bold purple4]{v}[/]";
                case '-':
                    return $"[bold grey39]{v}[/]";
                default:
                    return " ";
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
                var game = Games[gameNum];

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

        public ulong GetTotalPositionCount()
        {
            return Colors
                .Where(m => !PiecesUsed.Contains(m.Key))
                .Aggregate((ulong)1, (x, y) => x * (ulong)y.Value.Count());
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

        public void WriteShapeStats()
        {
            WriteShapeStats(LimePositions);
            WriteShapeStats(YellowPositions);
            WriteShapeStats(DarkBluePositions);
            WriteShapeStats(LightBluePositions);
            WriteShapeStats(RedPositions);
            WriteShapeStats(PinkPositions);
            WriteShapeStats(GreenPositions);
            WriteShapeStats(WhitePositions);
            WriteShapeStats(OrangePositions);
            WriteShapeStats(PeachPositions);
            WriteShapeStats(GrayPositions);
            WriteShapeStats(PurplePositions);
        }

        private void WriteShapeStats(List<Piece> positions)
        {
            foreach (var color in positions.GroupBy(m => m.Character))
            {
                Console.WriteLine(color.Key);
                foreach (var piece in color.GroupBy(m => m.Name))
                {
                    Console.WriteLine($"{piece.Key} - {piece.Count()}");
                }
                Console.WriteLine();
            }
        }
    }
}
