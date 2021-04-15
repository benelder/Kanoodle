﻿using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
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
        public static List<Piece> UnusedPieces { get; set; }
        public static List<char> PiecesUsed { get; set; }
        public static char[,,] BoardMap { get; set; }

        public static int PositionCount { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("CANOODLE!");
            
            BoardMap = new char[6, 6, 6];
            UsedLocations = new HashSet<Location>();
            PiecesUsed = new List<char>();

            InitializeBoard();

            AddInitialPiecesToBoard();

            LoadPossiblePositions();

            InitializeColors();

            Console.WriteLine("Board loaded. Initial setup looks like this");

            PrintBoard();

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
                Console.WriteLine("Piece positions tried: {0}", PositionCount);
            }

            Console.ReadLine();
        } // main

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

        private static void AddInitialPiecesToBoard()
        {
            LoadGame44();
            //LoadGame45();
        }

        private static void LoadGame45()
        {
            var green = new Green().Shapes.ElementAt(1);
            green.GRotation = 1;
            green.RootPosition = new Location(0, 0, 0);
            AddPieceToBoard(green);

            var yellow = new Yellow().Shapes.ElementAt(3);
            yellow.ARotation = 1;
            yellow.RootPosition = new Location(1, 0, 1);
            AddPieceToBoard(yellow);

            var lightBlue = new LightBlue().Shapes.ElementAt(3);
            lightBlue.RootPosition = new Location(1, 1, 0);
            AddPieceToBoard(lightBlue);

            var white = new White().Shapes.ElementAt(2);
            white.RootPosition = new Location(0, 3, 0);
            AddPieceToBoard(white);

            var orange = new Orange().Shapes.ElementAt(0);
            orange.ARotation = 1;
            orange.GRotation = 5;
            orange.RootPosition = new Location(1, 3, 0);
            AddPieceToBoard(orange);
        }

        private static void LoadGame44()
        {
            var red = new Red().Shapes.First();
            red.GRotation = 4;
            red.RootPosition = new Location(0, 2, 0);
            AddPieceToBoard(red);

            var lightBlue = new LightBlue().Shapes.First();
            lightBlue.GRotation = 2;
            lightBlue.RootPosition = new Location(3, 0, 0);
            AddPieceToBoard(lightBlue);

            var yellow = new Yellow().Shapes.First();
            yellow.GRotation = 2;
            yellow.ARotation = 1;
            yellow.RootPosition = new Location(4, 0, 0);
            AddPieceToBoard(yellow);

            var gray = new Gray().Shapes.First();
            gray.GRotation = 1;
            gray.ARotation = 0;
            gray.RootPosition = new Location(1, 3, 0);
            AddPieceToBoard(gray);

            var orange = new Orange().Shapes.ElementAt(2);
            orange.ARotation = 1;
            orange.GRotation = 2;
            orange.RootPosition = new Location(4, 1, 0);
            AddPieceToBoard(orange);
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
        }

        private static IEnumerable<Piece> GetUnusedPositions(IEnumerable<Piece> pieces)
        {
            return pieces.Where(m => m.GetAbsolutePosition().All(n => !UsedLocations.Contains(n.Offset)));
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
                                        RedPositions.Add(shape); // todo: check for uniqueness!
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
                PositionCount++;
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

                    for (int a = 0; a < 6; a++)
                    {
                        toPrint += BoardMap[a, b, g] + " ";
                    }

                    if (!string.IsNullOrWhiteSpace(toPrint.Trim())) Console.WriteLine(toPrint);
                }
                Console.WriteLine();
            }
        }
    }
}
