using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static List<Red> RedPositions { get; set; }
        public static List<Pink> PinkPositions { get; set; }
        public static List<Lime> LimePositions { get; set; }
        public static List<DarkBlue> DarkBluePositions { get; set; }
        public static List<LightBlue> LightBluePositions { get; set; }
        public static List<Green> GreenPositions { get; set; }
        public static List<Yellow> YellowPositions { get; set; }
        public static List<Purple> PurplePositions { get; set; }
        public static List<Peach> PeachPositions { get; set; }
        public static List<Gray> GrayPositions { get; set; }
        public static List<Orange> OrangePositions { get; set; }
        public static List<White> WhitePositions { get; set; }

        public static HashSet<Location> UsedLocations { get; set; }
        public static List<Piece> UnusedPieces { get; set; }
        public static List<Piece> PiecesUsed { get; set; }
        public static char[,,] BoardMap { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("CANOODLE!");
            BoardMap = new char[6, 6, 6];
            

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

            UsedLocations = new HashSet<Location>();

            AddPieceToBoard(new Red() { GRotation = 1, BRotation = 2, RootPosition = new Location(0, 0, 0) });

            LoadPossiblePositions();

            PrintBoard();

            foreach (var red in GetUnusedPositions(RedPositions))
            {
                if (!Collision(red))
                {
                    AddPieceToBoard(red);
                    PrintBoard();

                    foreach (var pink in GetUnusedPositions(PinkPositions))
                    {
                        if (!Collision(pink))
                        {
                            AddPieceToBoard(pink);
                            PrintBoard();

                            foreach (var darkBlue in GetUnusedPositions(DarkBluePositions))
                            {
                                if (!Collision(darkBlue))
                                {
                                    AddPieceToBoard(darkBlue);
                                    PrintBoard();

                                    foreach (var lime in GetUnusedPositions(LimePositions))
                                    {
                                        if (!Collision(lime))
                                        {
                                            AddPieceToBoard(lime);
                                            PrintBoard();

                                            foreach (var purple in GetUnusedPositions(PurplePositions))
                                            {
                                                if (!Collision(purple))
                                                {
                                                    AddPieceToBoard(purple);
                                                    PrintBoard();

                                                    foreach (var peach in GetUnusedPositions(PeachPositions))
                                                    {
                                                        if (!Collision(peach))
                                                        {
                                                            AddPieceToBoard(peach);
                                                            //PrintBoard();

                                                            foreach (var white in GetUnusedPositions(WhitePositions))
                                                            {
                                                                if (!Collision(white))
                                                                {
                                                                    AddPieceToBoard(white);
                                                                    //PrintBoard();

                                                                    foreach (var green in GetUnusedPositions(GreenPositions))
                                                                    {
                                                                        if (!Collision(green))
                                                                        {
                                                                            AddPieceToBoard(green);
                                                                            //PrintBoard();

                                                                            foreach (var yellow in GetUnusedPositions(YellowPositions))
                                                                            {
                                                                                if (!Collision(yellow))
                                                                                {
                                                                                    AddPieceToBoard(yellow);
                                                                                    //PrintBoard();

                                                                                    foreach (var orange in GetUnusedPositions(OrangePositions))
                                                                                    {
                                                                                        if (!Collision(orange))
                                                                                        {
                                                                                            AddPieceToBoard(orange);
                                                                                            //PrintBoard();

                                                                                            foreach (var lightBlue in GetUnusedPositions(LightBluePositions))
                                                                                            {
                                                                                                if (!Collision(lightBlue))
                                                                                                {
                                                                                                    AddPieceToBoard(lightBlue);
                                                                                                    //PrintBoard();

                                                                                                    foreach (var gray in GetUnusedPositions(GrayPositions))
                                                                                                    {
                                                                                                        if (!Collision(gray))
                                                                                                        {
                                                                                                            AddPieceToBoard(gray);

                                                                                                            break;
                                                                                                        }
                                                                                                    }

                                                                                                    RemovePieceFromBoard(lightBlue);
                                                                                                }
                                                                                            }

                                                                                            RemovePieceFromBoard(orange);
                                                                                        }
                                                                                    }

                                                                                    RemovePieceFromBoard(yellow);
                                                                                }
                                                                            }

                                                                            RemovePieceFromBoard(green);
                                                                        }
                                                                    }

                                                                    RemovePieceFromBoard(white);
                                                                }
                                                            }

                                                            RemovePieceFromBoard(peach);
                                                        }
                                                    }

                                                    RemovePieceFromBoard(purple);
                                                }
                                            }

                                            RemovePieceFromBoard(lime);
                                        }
                                    }

                                    RemovePieceFromBoard(darkBlue);
                                }
                            }

                            RemovePieceFromBoard(pink);
                        }
                    }

                    RemovePieceFromBoard(red);
                }
            }

            PrintBoard();


        } // main

        private static IEnumerable<Piece> GetUnusedPositions(IEnumerable<Piece> pieces)
        {
            return pieces.Where(m => m.GetAbsolutePosition().All(n => !UsedLocations.Contains(n.Offset)));
        }

        private static void LoadPossiblePositions()
        {
            RedPositions = new List<Red>();
            PinkPositions = new List<Pink>();
            PurplePositions = new List<Purple>();
            DarkBluePositions = new List<DarkBlue>();
            LightBluePositions = new List<LightBlue>();
            WhitePositions = new List<White>();
            GrayPositions = new List<Gray>();
            LimePositions = new List<Lime>();
            OrangePositions = new List<Orange>();
            PeachPositions = new List<Peach>();
            YellowPositions = new List<Yellow>();
            GreenPositions = new List<Green>();

            for (int g = 0; g < 6; g++)
            {
                for (int b = 0; b < 6; b++)
                {
                    for (int a = 0; a < 6; a++)
                    {
                        for (int rb = 0; rb < 3; rb++)
                        {
                            for (int ra = 0; ra < 3; ra++)
                            {
                                for (int rg = 0; rg < 6; rg++)
                                {
                                    var red = new Red() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!red.IsOutOfBounds() && red.Nodes.All(m=> !UsedLocations.Contains(m.Offset)))
                                        RedPositions.Add(red);

                                    var orange = new Orange() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!orange.IsOutOfBounds() && orange.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        OrangePositions.Add(orange);

                                    var pink = new Pink() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!pink.IsOutOfBounds() && pink.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        PinkPositions.Add(pink);

                                    var purple = new Purple() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!purple.IsOutOfBounds() && purple.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        PurplePositions.Add(purple);

                                    var gray = new Gray() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!gray.IsOutOfBounds() && gray.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        GrayPositions.Add(gray);

                                    var darkBlue = new DarkBlue() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!darkBlue.IsOutOfBounds() && darkBlue.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        DarkBluePositions.Add(darkBlue);

                                    var lightBlue = new LightBlue() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!lightBlue.IsOutOfBounds() && lightBlue.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        LightBluePositions.Add(lightBlue);

                                    var peach = new Peach() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!peach.IsOutOfBounds() && peach.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        PeachPositions.Add(peach);

                                    var white = new White() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!white.IsOutOfBounds() && white.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        WhitePositions.Add(white);

                                    var yellow = new Yellow() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!yellow.IsOutOfBounds() && yellow.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        YellowPositions.Add(yellow);

                                    var lime = new Lime() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!lime.IsOutOfBounds() && lime.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        LimePositions.Add(lime);

                                    var green = new Green() { RootPosition = new Location(a, b, g), ARotation = ra, BRotation = rb, GRotation = rg };
                                    if (!green.IsOutOfBounds() && green.Nodes.All(m => !UsedLocations.Contains(m.Offset)))
                                        GreenPositions.Add(green);
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
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var toPrint = "";

                    // indent
                    for (int l = 0; l < 6 - j; l++)
                    {
                        toPrint += " ";
                    }


                    for (int k = 0; k < 6; k++)
                    {
                        toPrint += BoardMap[k, j, i];
                    }

                    Console.WriteLine(toPrint);
                }
            }
        }
    }
}
