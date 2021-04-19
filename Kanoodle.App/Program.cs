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
        public static char[,,] BoardMap { get; set; }
        public static int PositionCount { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("KANOODLE!");
            var escape = false;
            while (!escape)
            {
                Console.WriteLine("Choose and option: (S)olver, (P)ieces, (E)xit");
                var module = Console.ReadLine();

                if (module == "S")
                {
                    Solver();
                }
                else if (module == "P")
                {
                    Pieces();
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

        private static void Pieces()
        {
            var escape = false;
            BoardMap = new char[6, 6, 6];
            UsedLocations = new HashSet<Location>();
            PiecesUsed = new List<char>();
            LoadPossiblePositions();
            InitializeColors();

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

        private static void DisplayPositions(char module)
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
                            var positions = Colors[module].Where(m=>m.GetAbsolutePosition().Any(n=>n.Offset.A == a && n.Offset.B == b && n.Offset.G == g)).ToArray();
                            var total = positions.Count();

                            for (int i = 0; i < total; i++)
                            {
                                var item = positions[i];
                                InitializeBoard();
                                AddPieceToBoard(item);
                                PrintBoard();
                                Console.WriteLine("Position {1} of {2}", item.Name, i, total);
                                Console.WriteLine("{0} @ Root:{1} Ar:{2} Br:{3} Gr:{4}", item.Name, item.RootPosition, item.ARotation, item.BRotation, item.GRotation);
                                var next = Console.ReadKey();
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
                    var positions = Colors[module];
                    var total = positions.Count();
                    for (int i = 0; i < total; i++)
                    {
                        var item = positions[i];
                        InitializeBoard();
                        AddPieceToBoard(item);
                        PrintBoard();
                        Console.WriteLine("{0} position {1} of {2}", item.Name, i, total);
                        Console.WriteLine("Root:{0} Ar:{1} Br:{2} Gr:{3}", item.RootPosition, item.ARotation, item.BRotation, item.GRotation);
                        var next = Console.ReadKey();
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

        private static void Solver()
        {
            BoardMap = new char[6, 6, 6];
            UsedLocations = new HashSet<Location>();
            PiecesUsed = new List<char>();
            var boardInitialized = false;

            InitializeBoard();

            while (!boardInitialized)
            {
                Console.WriteLine("Please enter a number between 1 and 100 to load a game");

                var gameNumStr = Console.ReadLine();

                var isNum = int.TryParse(gameNumStr, out int gameNum);

                if (!isNum)
                {
                    Console.WriteLine("Not a number");
                    continue;
                }

                var piecesAdded = AddInitialPiecesToBoard(gameNum);

                if (!piecesAdded)
                {
                    Console.WriteLine("That game is not in the catalog. Please try a different number");
                    continue;
                }

                boardInitialized = true;
            }

            LoadPossiblePositions();

            InitializeColors();

            Console.WriteLine("Board loaded. Initial setup looks like this");

            PrintBoard();

            var totalPositionCount = GetTotalPositionCount();
            Console.WriteLine("There are {0} total position combinations possible in this game", totalPositionCount.ToString("N0"));

            Console.WriteLine("Press any key to attempt to solve");

            Console.ReadKey();

            var timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Attempting to place pieces");


            PlacePieces();

            if (SolutionFound)
            {
                timer.Stop();
                PrintBoard();
                Console.WriteLine("SOLUTION FOUND!!");
                Console.WriteLine("Time elapsed: {0}", timer.Elapsed);
                Console.WriteLine("Piece positions tried: {0}", PositionCount.ToString("N0"));
            }

            Console.ReadLine();
        }

        private static ulong GetTotalPositionCount()
        {
            return Colors
                .Where(m => !PiecesUsed.Contains(m.Key))
                .Aggregate((ulong)1, (x, y) => x * (ulong)y.Value.Count());
        }

        private static bool SolutionFound;
        private static void PlacePieces()
        {
            var unusedColors = Colors.Where(m => !PiecesUsed.Contains(m.Key)).ToArray();
            if (unusedColors.Length == 0)
            {
                SolutionFound = true;
                return;
            }

            var pieces = unusedColors.First().Value;

            foreach (var position in pieces)
            {
                PositionCount++;

                if (!Collision(position))
                {
                    AddPieceToBoard(position);
                    PlacePieces();
                    if (SolutionFound) return;
                    RemovePieceFromBoard(position);
                }
            }
        }

        private static void InitializeColors()
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

        private static Dictionary<int, IEnumerable<Piece>> _games;
        public static Dictionary<int, IEnumerable<Piece>> Games
        {
            get
            {

                if (_games == null)
                {
                    _games = new Dictionary<int, IEnumerable<Piece>>();

                    _games.Add(44, GameFactory.Game44());
                    _games.Add(45, GameFactory.Game45());
                    _games.Add(95, GameFactory.Game95());
                    _games.Add(96, GameFactory.Game96());
                    _games.Add(99, GameFactory.Game99());
                    _games.Add(100, GameFactory.Game100());
                }

                return _games;
            }
        }

        private static bool AddInitialPiecesToBoard(int gameNum)
        {
            try
            {
                var game = Games[gameNum];

                foreach (var piece in game)
                {
                    AddPieceToBoard(piece);
                }

                return true;
            }
            catch (Exception)
            {
                InitializeBoard();
                return false;
            }
        }

        private static void InitializeBoard()
        {
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

        private static void LoadPossiblePositions()
        {
            RedPositions = new List<Piece>();
            PinkPositions = new List<Piece>();
            PurplePositions = new List<Piece>();
            DarkBluePositions = new List<Piece>();
            LightBluePositions = new List<Piece>();
            WhitePositions = new List<Piece>();
            GrayPositions = new List<Piece>();
            LimePositions = new List<Piece>();
            OrangePositions = new List<Piece>();
            PeachPositions = new List<Piece>();
            YellowPositions = new List<Piece>();
            GreenPositions = new List<Piece>();

            for (int g = 0; g < 6; g++)
            {
                for (int b = 0; b < 6; b++)
                {
                    for (int a = 0; a < 6; a++)
                    {
                        for (int rg = 0; rg < 6; rg++)
                        {
                            // B rotations
                            for (int rb = 0; rb < 3; rb++)
                            {
                                if (rb == 1 && rg == 1) continue; // incompatible transformation

                                var red = new Red();
                                foreach (var shape in red.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && RedPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        RedPositions.Add(shape);
                                }

                                var orange = new Orange();
                                foreach (var shape in orange.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && OrangePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        OrangePositions.Add(shape);
                                }

                                var pink = new Pink();
                                foreach (var shape in pink.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && PinkPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        PinkPositions.Add(shape);
                                }

                                var purple = new Purple();
                                foreach (var shape in purple.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && PurplePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        PurplePositions.Add(shape);
                                }

                                var gray = new Gray();
                                foreach (var shape in gray.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && GrayPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        GrayPositions.Add(shape);
                                }

                                var darkBlue = new DarkBlue();
                                foreach (var shape in darkBlue.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && DarkBluePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        DarkBluePositions.Add(shape);
                                }

                                var lightBlue = new LightBlue();
                                foreach (var shape in lightBlue.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && LightBluePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        LightBluePositions.Add(shape);
                                }

                                var peach = new Peach();
                                foreach (var shape in peach.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && PeachPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        PeachPositions.Add(shape);
                                }

                                var white = new White();
                                foreach (var shape in white.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && WhitePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        WhitePositions.Add(shape);
                                }

                                var yellow = new Yellow();
                                foreach (var shape in yellow.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && YellowPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        YellowPositions.Add(shape);
                                }

                                var lime = new Lime();
                                foreach (var shape in lime.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && LimePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        LimePositions.Add(shape);
                                }

                                var green = new Green();
                                foreach (var shape in green.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && GreenPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        GreenPositions.Add(shape);
                                }
                            }

                            // A rotations
                            for (int ra = 0; ra < 3; ra++)
                            {
                                var red = new Red();
                                foreach (var shape in red.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && RedPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        RedPositions.Add(shape); 
                                }

                                var orange = new Orange();
                                foreach (var shape in orange.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && OrangePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        OrangePositions.Add(shape);
                                }

                                var pink = new Pink();
                                foreach (var shape in pink.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && PinkPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        PinkPositions.Add(shape);
                                }

                                var purple = new Purple();
                                foreach (var shape in purple.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && PurplePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        PurplePositions.Add(shape);
                                }

                                var gray = new Gray();
                                foreach (var shape in gray.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && GrayPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        GrayPositions.Add(shape);
                                }

                                var darkBlue = new DarkBlue();
                                foreach (var shape in darkBlue.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && DarkBluePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        DarkBluePositions.Add(shape);
                                }

                                var lightBlue = new LightBlue();
                                foreach (var shape in lightBlue.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && LightBluePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        LightBluePositions.Add(shape);
                                }

                                var peach = new Peach();
                                foreach (var shape in peach.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && PeachPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        PeachPositions.Add(shape);
                                }

                                var white = new White();
                                foreach (var shape in white.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && WhitePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        WhitePositions.Add(shape);
                                }

                                var yellow = new Yellow();
                                foreach (var shape in yellow.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && YellowPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        YellowPositions.Add(shape);
                                }

                                var lime = new Lime();
                                foreach (var shape in lime.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && LimePositions.All(m => !m.IsInSamePositionAs(shape)))
                                        LimePositions.Add(shape);
                                }

                                var green = new Green();
                                foreach (var shape in green.Shapes)
                                {
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (!shape.IsOutOfBounds() && shape.GetAbsolutePosition().All(m => !UsedLocations.Contains(m.Offset))
                                        && GreenPositions.All(m => !m.IsInSamePositionAs(shape)))
                                        GreenPositions.Add(shape);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool Collision(Piece piece)
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

        private static void AddPieceToBoard(Piece piece)
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
                RemovePieceFromBoard(piece);
                throw;
            }
        }

        private static void RemovePieceFromBoard(Piece piece)
        {
            var abs = piece.GetAbsolutePosition();
            for (int i = 0; i < abs.Length; i++)
            {
                BoardMap[abs[i].Offset.A, abs[i].Offset.B, abs[i].Offset.G] = '-';
                UsedLocations.Remove(abs[i].Offset);
            }
            PiecesUsed.Remove(piece.Character);
        }

        public static void PrintBoard()
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

        private static string FormatPiece(char v)
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
    }
}
