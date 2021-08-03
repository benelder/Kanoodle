using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanoodle.App
{
    public class PieceRegistry
    {
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

        public PieceRegistry()
        {

            LoadPossiblePositions();
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

        private void LoadPossiblePositions()
        {
            RedPositions = LoadPositionsForColor<Red>();
            PinkPositions = LoadPositionsForColor<Pink>();
            PurplePositions = LoadPositionsForColor<Purple>();
            DarkBluePositions = LoadPositionsForColor<DarkBlue>();
            LightBluePositions = LoadPositionsForColor<LightBlue>();
            WhitePositions = LoadPositionsForColor<White>();
            GrayPositions = LoadPositionsForColor<Gray>();
            LimePositions = LoadPositionsForColor<Lime>();
            OrangePositions = LoadPositionsForColor<Orange>();
            PeachPositions = LoadPositionsForColor<Peach>();
            YellowPositions = LoadPositionsForColor<Yellow>();
            GreenPositions = LoadPositionsForColor<Green>();

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

        private int _totalPositionsTested = 0;

        private List<Piece> LoadPositionsForColor<T>() where T : Piece, new()
        {
            var toRet = new List<Piece>();


            for (int z = 0; z < 6; z++) // for each root position
            {
                for (int y = 0; y < 6; y++) // for each root position
                {
                    for (int x = 0; x < 6; x++) // for each root position
                    {
                        if (x + y + z > 5) // will be out of bounds
                            continue;

                        for (int r = 0; r < 6; r++) // for each rotated position
                        {
                            for (int p = 0; p < 3; p++) // for each plane
                            {
                                var piece = new T();

                                piece.RootPosition = new Location(x, y, z);
                                piece.Plane = p;
                                piece.Rotation = r;
                                piece.Lean = false;
                                piece.MirrorX = false;

                                // test flat orientation
                                _totalPositionsTested++;

                                if (!piece.IsOutOfBounds())
                                {
                                    if (!toRet.Any(m => m.IsInSamePositionAs(piece)))
                                    {
                                        toRet.Add(piece);
                                    }
                                }

                                // test lean orientation
                                _totalPositionsTested++;

                                piece = new T();

                                piece.RootPosition = new Location(x, y, z);
                                piece.Plane = p;
                                piece.Rotation = r;
                                piece.Lean = true;
                                piece.MirrorX = false;

                                if (!piece.IsOutOfBounds())
                                {
                                    if (!toRet.Any(m => m.IsInSamePositionAs(piece)))
                                    {
                                        toRet.Add(piece);
                                    }
                                }


                                // flip x
                                piece = new T();

                                piece.RootPosition = new Location(x, y, z);
                                piece.Plane = p;
                                piece.Rotation = r;
                                piece.Lean = false;
                                piece.MirrorX = true;

                                // test flat orientation
                                _totalPositionsTested++;

                                if (!piece.IsOutOfBounds())
                                {
                                    if (!toRet.Any(m => m.IsInSamePositionAs(piece)))
                                    {
                                        toRet.Add(piece);
                                    }
                                }

                                // test lean orientation
                                _totalPositionsTested++;

                                piece = new T();

                                piece.RootPosition = new Location(x, y, z);
                                piece.Plane = p;
                                piece.Rotation = r;
                                piece.Lean = true;
                                piece.MirrorX = true;

                                if (!piece.IsOutOfBounds())
                                {
                                    if (!toRet.Any(m => m.IsInSamePositionAs(piece)))
                                    {
                                        toRet.Add(piece);
                                    }
                                }
                            }
                        }
                    }
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
