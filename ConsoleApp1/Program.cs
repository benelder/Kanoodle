using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static HashSet<string> Attempts { get; set; }
        public static List<Piece> UnusedPieces { get; set; }
        public static List<Piece> PiecesUsed { get; set; }
        public static char[,,] BoardMap { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("CANOODLE!");
            Attempts = new HashSet<string>();
            BoardMap = new char[6, 6, 6];
            PiecesUsed = new List<Piece>();
            UnusedPieces = new List<Piece>
            {


                new Gray(),
                new Purple(),

                new Yellow(),

                new Green(),
                new White(),

                new Orange(),

                new LightBlue(),

                new Lime(),

                new DarkBlue(),
                new Peach(),

                new Red(),

                new Pink()
            };

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

            PrintBoard();

            var escape = false;

            var targetLocation = GetNextEmptyLocation();

            Console.WriteLine("Attempting to place pieces at location {0}, {1}, {2}", targetLocation.A, targetLocation.B, targetLocation.G);
            var lastAttempt = "";
            var pieceCount = UnusedPieces.Count;
            var pieceAttempAtPosition = 0;
            while (UnusedPieces.Count > 0)
            {
                while (!targetLocation.Equals(new Location(-1, -1, -1)))
                {
                    if (escape) break;
                    pieceCount = UnusedPieces.Count;

                    if (pieceAttempAtPosition == pieceCount)
                    {
                        RemoveLastPlacedPiece();
                        targetLocation = GetNextEmptyLocation();
                        pieceAttempAtPosition = 0;
                        PrintBoard();

                        continue;
                    }
                    var piece = UnusedPieces[^1];
                    pieceAttempAtPosition++;

                    if (lastAttempt == piece.Name)
                    {
                        escape = true;
                        Console.WriteLine("Aborting, repeating same piece");
                        break;
                    }
                    else
                    {
                        lastAttempt = piece.Name;
                    };

                    var piecePlaced = false;

                    for (int rb = 0; rb < 3; rb++)
                    {
                        for (int ra = 0; ra < 3; ra++)
                        {
                            for (int rg = 0; rg < 6; rg++)
                            {



                                piece.RootPosition = targetLocation;
                                piece.ARotation = ra;
                                piece.BRotation = rb;
                                piece.GRotation = rg;

                                if (Attempts.Contains(piece.AbsId()))
                                    continue;

                                //Console.WriteLine("Attempting to place {0} at location {1}, {2}, {3} with rotation {4}, {5}, {6}", piece.Name, targetLocation.A, targetLocation.B, targetLocation.G, ra, rb, rg);

                                var abs = piece.GetAbsolutePosition();

                                var absString = "";
                                for (int i = 0; i < abs.Length; i++)
                                {
                                    if (i == 0)
                                        absString = abs[0].ToString();
                                    else
                                    {
                                        absString += $", {abs[i]}";
                                    }
                                }

                                Attempts.Add(piece.AbsId());

                                var isInBounds = !piece.IsOutOfBounds();
                                //Console.WriteLine("Absolute position is: {0}; InBounds = {1}", absString, isInBounds.ToString().ToUpper());

                                if (isInBounds)
                                {
                                    Console.WriteLine($"Attempting to place {piece.Name} piece");

                                    if (!Collision(piece))
                                    {
                                        AddPieceToBoard(piece);
                                        PrintBoard();
                                        piecePlaced = true;
                                        pieceAttempAtPosition = 0;
                                        Console.WriteLine($"{piece.Name} placed successfully");

                                    }
                                    else
                                    {
                                        Console.WriteLine($"Collision detected. Attempting an alternate position");
                                    }
                                }

                                if (piecePlaced) break;
                            }

                            if (piecePlaced) break;
                        }

                        if (piecePlaced) break;
                    }

                    if (!piecePlaced)
                    {
                        // if we get here, piece wont fit in this position,
                        // pop it off the list and add to front
                        UnusedPieces.Remove(piece);
                        UnusedPieces.Insert(0, piece);
                    }
                    else
                    {
                        targetLocation = GetNextEmptyLocation();
                    }
                }
            }
        } // main

        private static void RemoveLastPlacedPiece()
        {
            var lastPiece = PiecesUsed[^1];
            Console.WriteLine($"Removing {lastPiece.Name}");

            ClearPieceFromMap(lastPiece);
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
                }

                PiecesUsed.Add(piece);
                UnusedPieces.Remove(piece);

            }
            catch (Exception)
            {
                ClearPieceFromMap(piece);
                throw;
            }


        }

        private static void ClearPieceFromMap(Piece piece)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (BoardMap[i, j, k] == piece.Character)
                            BoardMap[i, j, k] = '-';
                    }
                }
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
