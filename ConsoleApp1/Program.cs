using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
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
        public static List<Piece> PiecesUsed { get; set; }
        public static char[,,] BoardMap { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("CANOODLE!");
            BoardMap = new char[6, 6, 6];
            UsedLocations = new HashSet<Location>();

            InitializeBoard();

            AddInitialPiecesToBoard();

            LoadPossiblePositions();

            PrintBoard();

            //foreach (var red in GetUnusedPositions(RedPositions))
            //{
            //    if (!Collision(red))
            //    {
            //        AddPieceToBoard(red);
            //        PrintBoard();
            var count = 1;
            var limePositions = GetUnusedPositions(LimePositions);
            var solutionFound = false;

            foreach (var lime in limePositions)
            {
                Console.WriteLine("Fitting Lime piece, position {0} of {1}", count, limePositions.Count());
                count++;
                if (!Collision(lime))
                {
                    AddPieceToBoard(lime);
                    //PrintBoard();

                    foreach (var darkBlue in GetUnusedPositions(DarkBluePositions))
                    {
                        if (!Collision(darkBlue))
                        {
                            AddPieceToBoard(darkBlue);
                            //PrintBoard();

                            foreach (var pink in GetUnusedPositions(PinkPositions))
                            {
                                if (!Collision(pink))
                                {
                                    AddPieceToBoard(pink);
                                    //PrintBoard();

                                    foreach (var white in GetUnusedPositions(WhitePositions))
                                    {
                                        if (!Collision(white))
                                        {
                                            AddPieceToBoard(white);
                                            //PrintBoard();

                                            foreach (var peach in GetUnusedPositions(PeachPositions))
                                            {
                                                if (!Collision(peach))
                                                {
                                                    AddPieceToBoard(peach);
                                                    //PrintBoard();

                                                    foreach (var purple in GetUnusedPositions(PurplePositions))
                                                    {
                                                        if (!Collision(purple))
                                                        {
                                                            AddPieceToBoard(purple);
                                                            //PrintBoard();

                                                            foreach (var green in GetUnusedPositions(GreenPositions))
                                                            {
                                                                if (!Collision(green))
                                                                {
                                                                    AddPieceToBoard(green);
                                                                    PrintBoard();

                                                                    //foreach (var yellow in GetUnusedPositions(YellowPositions))
                                                                    //{
                                                                    //    if (!Collision(yellow))
                                                                    //    {
                                                                    //        AddPieceToBoard(yellow);
                                                                    //        //PrintBoard();

                                                                    //foreach (var orange in GetUnusedPositions(OrangePositions))
                                                                    //{
                                                                    //    if (!Collision(orange))
                                                                    //    {
                                                                    //        AddPieceToBoard(orange);
                                                                    //        //PrintBoard();

                                                                    //        foreach (var lightBlue in GetUnusedPositions(LightBluePositions))
                                                                    //        {
                                                                    //            if (!Collision(lightBlue))
                                                                    //            {
                                                                    //                AddPieceToBoard(lightBlue);
                                                                    //                //PrintBoard();

                                                                    //                foreach (var gray in GetUnusedPositions(GrayPositions))
                                                                    //                {
                                                                    //                    if (!Collision(gray))
                                                                    //                    {
                                                                    //                        AddPieceToBoard(gray);

                                                                    Console.WriteLine("SOLUTION FOUND!!");
                                                                    solutionFound = true;
                                                                    break;
                                                                    //                    }
                                                                    //                }

                                                                    //                RemovePieceFromBoard(lightBlue);
                                                                    //            }
                                                                    //        }

                                                                    //        RemovePieceFromBoard(orange);
                                                                    //    }
                                                                    //}

                                                                    //        RemovePieceFromBoard(yellow);
                                                                    //    }
                                                                    //}

                                                                    //RemovePieceFromBoard(green);
                                                                }
                                                            }
                                                            if (solutionFound) break;
                                                            RemovePieceFromBoard(purple);
                                                        }
                                                    }
                                                    if (solutionFound) break;
                                                    RemovePieceFromBoard(peach);
                                                }
                                            }
                                            if (solutionFound) break;
                                            RemovePieceFromBoard(white);
                                        }
                                    }
                                    if (solutionFound) break;
                                    RemovePieceFromBoard(pink);
                                }
                            }
                            if (solutionFound) break;
                            RemovePieceFromBoard(darkBlue);
                        }
                    }

                    if (solutionFound) break;
                    RemovePieceFromBoard(lime);
                }
                if (solutionFound) break;
            }

            PrintBoard();
            Console.ReadLine();
        } // main

        private static void AddInitialPiecesToBoard()
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

        private static void RemoveLastPlacedPiece()
        {
            var lastPiece = PiecesUsed[^1];
            Console.WriteLine($"Removing {lastPiece.Name}");

            RemovePieceFromBoard(lastPiece);
            PiecesUsed.Remove(lastPiece);
            UnusedPieces.Insert(0, lastPiece);
        }

        private static Location GetNextEmptyLocation()
        {
            for (int g = 0; g < 6; g++)
            {
                for (int b = 0; b < 6; b++)
                {
                    for (int a = 0; a < 6; a++)
                    {
                        if (BoardMap[a, b, g] == '-')
                            return new Location(a, b, g);
                    }
                }
            }

            return new Location(-1, -1, -1);
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
            }
            catch (Exception ex)
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
        }

        public static void PrintBoard()
        {
            for (int g = 5; g >= 0; g--)
            {
                for (int b = 5; b >= 0; b--)
                {
                    var toPrint = string.Empty;

                    for (int l = 0; l < 6 - g; l++)
                    {
                        toPrint += " ";
                    }

                    for (int a = 0; a < 6; a++)
                    {
                        toPrint += BoardMap[a, b, g];
                    }

                    if(!string.IsNullOrEmpty(toPrint.Trim())) Console.WriteLine(toPrint);
                }
            }
        }
    }
}
