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

        public static IEnumerable<Piece> Game89()
        {
            var toRet = new List<Piece>();

            var yellow = new Yellow().Shapes.ElementAt(3);
            yellow.BRotation = 2;
            yellow.RootPosition = new Location(3, 0, 0);
            toRet.Add(yellow);

            var peach = new Peach().Shapes.ElementAt(0);
            peach.GRotation = 4;
            peach.ARotation = 1;
            peach.RootPosition = new Location(1, 3, 0);
            toRet.Add(peach);

            var lightBlue = new LightBlue().Shapes.ElementAt(4);
            lightBlue.RootPosition = new Location(3, 2, 0);
            lightBlue.BRotation = 2;
            toRet.Add(lightBlue);

            return toRet;
        }

        public static IEnumerable<Piece> Game201()
        {
            var toRet = new List<Piece>();

            var pink = new Pink().Shapes.ElementAt(0);
            pink.RootPosition = new Location(2, 0, 0);
            toRet.Add(pink);

            var peach = new Peach().Shapes.ElementAt(0);
            peach.ARotation = 1;
            peach.RootPosition = new Location(1, 1, 0);
            toRet.Add(peach);

            var orange = new Orange().Shapes.ElementAt(0);
            orange.RootPosition = new Location(0, 0, 0);
            orange.ARotation = 1;
            toRet.Add(orange);

            return toRet;
        }

        public static IEnumerable<Piece> Game202()
        {
            var toRet = new List<Piece>();

            var gray = new Gray().Shapes.ElementAt(0);
            gray.RootPosition = new Location(0, 0, 0);
            toRet.Add(gray);

            var red = new Red().Shapes.ElementAt(0);
            red.GRotation = 1;
            red.RootPosition = new Location(0, 3, 0);
            toRet.Add(red);

            var orange = new Orange().Shapes.ElementAt(3);
            orange.BRotation = 2;
            orange.RootPosition = new Location(3, 0, 0);
            toRet.Add(orange);

            var purple = new Purple().Shapes.ElementAt(4);
            purple.BRotation = 2;
            purple.RootPosition = new Location(4, 0, 0);
            toRet.Add(purple);

            return toRet;
        }

        public static IEnumerable<Piece> Game203()
        {
            var toRet = new List<Piece>();

            var gray = new Gray().Shapes.ElementAt(0);
            gray.RootPosition = new Location(2, 1, 0);
            toRet.Add(gray);

            var yellow = new Yellow().Shapes.ElementAt(2);
            yellow.GRotation = 1;
            yellow.RootPosition = new Location(1, 2, 0);
            toRet.Add(yellow);

            var orange = new Orange().Shapes.ElementAt(0);
            orange.GRotation = 1;
            orange.ARotation = 1;
            orange.RootPosition = new Location(0, 1, 0);
            toRet.Add(orange);

            var purple = new Purple().Shapes.ElementAt(0);
            purple.RootPosition = new Location(0, 0, 0);
            toRet.Add(purple);

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

        public static IEnumerable<Piece> Game95()
        {
            var toRet = new List<Piece>();

            var white = new White().Shapes.ElementAt(4);
            white.BRotation = 1;
            white.RootPosition = new Location(0, 2, 0);
            toRet.Add(white);

            var yellow = new Yellow().Shapes.ElementAt(0);
            yellow.GRotation = 5;
            yellow.ARotation = 1;
            yellow.RootPosition = new Location(0, 3, 0);
            toRet.Add(yellow);

            var orange = new Orange().Shapes.ElementAt(1);
            orange.GRotation = 2;
            orange.ARotation = 1;
            orange.RootPosition = new Location(1, 2, 2);
            toRet.Add(orange);

            return toRet;
        }

        public static IEnumerable<Piece> Game99()
        {
            var toRet = new List<Piece>();

            var white = new White().Shapes.ElementAt(2);
            white.ARotation = 1;
            white.GRotation = 5;
            white.RootPosition = new Location(1, 4, 0);
            toRet.Add(white);

            var yellow = new Yellow().Shapes.ElementAt(0);
            yellow.GRotation = 4;
            yellow.ARotation = 1;
            yellow.RootPosition = new Location(0, 5, 0);
            toRet.Add(yellow);

            var purple = new Purple().Shapes.ElementAt(5);
            purple.GRotation = 1;
            purple.RootPosition = new Location(0, 2, 0);
            toRet.Add(purple);

            return toRet;
        }

        public static IEnumerable<Piece> Game96()
        {
            var toRet = new List<Piece>();

            var green = new Green().Shapes.ElementAt(4);
            green.RootPosition = new Location(3, 1, 0);
            green.GRotation = 1;
            toRet.Add(green);

            var peach = new Peach().Shapes.ElementAt(0);
            peach.ARotation = 1;
            peach.RootPosition = new Location(0, 2, 0);
            toRet.Add(peach);

            var purple = new Purple().Shapes.ElementAt(5);
            purple.BRotation = 1;
            purple.GRotation = 3;
            purple.RootPosition = new Location(0, 4, 0);
            toRet.Add(purple);

            return toRet;
        }
    }
}
