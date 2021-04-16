using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanoodle.App
{
    public static class GameFactory
    {
        public static IEnumerable<Piece> Game45()
        {
            var toRet = new List<Piece>();

            var green = new Green().Shapes.ElementAt(1);
            green.GRotation = 1;
            green.RootPosition = new Location(0, 0, 0);
            toRet.Add(green);

            var yellow = new Yellow().Shapes.ElementAt(3);
            yellow.ARotation = 1;
            yellow.RootPosition = new Location(1, 0, 1);
            toRet.Add(yellow);

            var lightBlue = new LightBlue().Shapes.ElementAt(3);
            lightBlue.RootPosition = new Location(1, 1, 0);
            toRet.Add(lightBlue);

            var white = new White().Shapes.ElementAt(2);
            white.RootPosition = new Location(0, 3, 0);
            toRet.Add(white);

            var orange = new Orange().Shapes.ElementAt(0);
            orange.ARotation = 1;
            orange.GRotation = 5;
            orange.RootPosition = new Location(1, 3, 0);
            toRet.Add(orange);

            return toRet;
        }

        public static IEnumerable<Piece> Game100()
        {
            var toRet = new List<Piece>();

            var green = new Green().Shapes.ElementAt(3);
            green.BRotation = 1;
            green.GRotation = 4;
            green.RootPosition = new Location(2, 2, 0);
            toRet.Add(green);

            var gray = new Gray().Shapes.ElementAt(0);
            gray.GRotation = 4;
            gray.ARotation = 1;
            gray.RootPosition = new Location(0, 3, 0);
            toRet.Add(gray);

            var purple = new Purple().Shapes.ElementAt(5);
            purple.GRotation = 2;
            purple.ARotation = 1;
            purple.RootPosition = new Location(2, 2, 1);
            toRet.Add(purple);

            return toRet;
        }

        public static IEnumerable<Piece> Game44()
        {
            var toRet = new List<Piece>();

            var red = new Red().Shapes.First();
            red.GRotation = 4;
            red.RootPosition = new Location(0, 2, 0);
            toRet.Add(red);

            var lightBlue = new LightBlue().Shapes.First();
            lightBlue.GRotation = 2;
            lightBlue.RootPosition = new Location(3, 0, 0);
            toRet.Add(lightBlue);

            var yellow = new Yellow().Shapes.First();
            yellow.GRotation = 2;
            yellow.ARotation = 1;
            yellow.RootPosition = new Location(4, 0, 0);
            toRet.Add(yellow);

            var gray = new Gray().Shapes.First();
            gray.GRotation = 1;
            gray.ARotation = 0;
            gray.RootPosition = new Location(1, 3, 0);
            toRet.Add(gray);

            var orange = new Orange().Shapes.ElementAt(2);
            orange.ARotation = 1;
            orange.GRotation = 2;
            orange.RootPosition = new Location(4, 1, 0);
            toRet.Add(orange);

            return toRet;
        }
    }
}
