﻿using Kanoodle.Core;
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

        private List<Piece> LoadPositionsForColor<T>() where T : Color, new()
        {
            var color = new T();
            var toRet = new List<Piece>();

            for (int i = 0; i < color.Shapes.Count(); i++)
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
                                    color = new T();
                                    var shape = color.Shapes.ElementAt(i);

                                    shape.RootPosition = new Location(a, b, g);

                                    shape.ARotation = 0;
                                    shape.BRotation = rb;
                                    shape.GRotation = rg;

                                    if (shape.IsOutOfBounds())
                                        continue;

                                    if (toRet.Any(m => m.IsInSamePositionAs(shape)))
                                        continue;

                                    toRet.Add(shape);
                                }

                                // A rotations
                                for (int ra = 1; ra < 3; ra++) // ra starts at 1 because zero was already accounted for in the B rotation loop above
                                {

                                    _totalPositionsTested++;
                                    color = new T();
                                    var shape = color.Shapes.ElementAt(i);
                                    shape.RootPosition = new Location(a, b, g);
                                    shape.ARotation = ra;
                                    shape.BRotation = 0;
                                    shape.GRotation = rg;

                                    if (shape.IsOutOfBounds())
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