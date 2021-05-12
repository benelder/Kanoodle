﻿using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanoodle.App
{
    public class CodeGenerator
    {
        private void GenerateCode(Piece piece)
        {
            var varName = piece.Character.ToString().ToLower();

            Console.WriteLine($"    var {varName} = new {GetColorName(piece.Character)}().Shapes.ElementAt({piece.Name});");
            Console.WriteLine($"    {varName}.RootPosition = new Location({piece.RootPosition.A}, {piece.RootPosition.B}, {piece.RootPosition.G});");
            Console.WriteLine($"    {varName}.ARotation = {piece.ARotation};");
            Console.WriteLine($"    {varName}.BRotation = {piece.BRotation};");
            Console.WriteLine($"    {varName}.GRotation = {piece.GRotation};");
            Console.WriteLine($"    toRet.Add({varName});");
            Console.WriteLine();
        }

        public void GenerateCode(IEnumerable<Piece> positionsUsed)
        {
            Console.WriteLine("public static IEnumerable<Piece> GameX()");
            Console.WriteLine("{");
            Console.WriteLine("    var toRet = new List<Piece>();");
            Console.WriteLine();

            for (int i = 0; i < positionsUsed.Count(); i++)
            {
                GenerateCode(positionsUsed.ElementAt(i));
            }

            Console.WriteLine("    return toRet;");
            Console.WriteLine("}");
            Console.WriteLine();
        }

        private string GetColorName(char c)
        {
            switch (c)
            {
                case 'A': return "Lime";
                case 'B': return "Yellow";
                case 'C': return "DarkBlue";
                case 'D': return "LightBlue";
                case 'E': return "Red";
                case 'F': return "Pink";
                case 'G': return "Green";
                case 'H': return "White";
                case 'I': return "Orange";
                case 'J': return "Peach";
                case 'K': return "Gray";
                case 'L': return "Purple";
                default: throw new Exception("Invlaid color char");
            }
        }

    }
}