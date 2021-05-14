using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanoodle.App
{
    public static class GameFactory
    {
        private static Dictionary<int, IEnumerable<Piece>> _games;
        public static Dictionary<int, IEnumerable<Piece>> Games
        {
            get
            {

                if (_games == null)
                {
                    _games = new Dictionary<int, IEnumerable<Piece>>();

                    _games.Add(20, Game20());
                    _games.Add(28, Game28());
                    _games.Add(44, Game44());
                    _games.Add(45, Game45());
                    _games.Add(89, Game89());
                    _games.Add(95, Game95());
                    _games.Add(96, Game96());
                    _games.Add(99, Game99());
                    _games.Add(100, Game100());
                    _games.Add(201, Game201());
                    _games.Add(202, Game202());
                    _games.Add(203, Game203());
                    _games.Add(204, Game204());
                    _games.Add(205, Game205());
                    _games.Add(206, Game206());
                    _games.Add(207, Game207());
                    _games.Add(208, Game208());
                }

                return _games;
            }
        }


        public static IEnumerable<Piece> Game208()
        {
            var toRet = new List<Piece>();

            var h = new White().Shapes.ElementAt(0);
            h.RootPosition = new Location(0, 0, 0);
            h.ARotation = 0;
            h.BRotation = 0;
            h.GRotation = 0;
            toRet.Add(h);

            var b = new Yellow().Shapes.ElementAt(0);
            b.RootPosition = new Location(2, 3, 0);
            b.ARotation = 0;
            b.BRotation = 2;
            b.GRotation = 2;
            toRet.Add(b);

            var k = new Gray().Shapes.ElementAt(0);
            k.RootPosition = new Location(4, 0, 0);
            k.ARotation = 0;
            k.BRotation = 2;
            k.GRotation = 0;
            toRet.Add(k);

            var e = new Red().Shapes.ElementAt(0);
            e.RootPosition = new Location(0, 3, 0);
            e.ARotation = 2;
            e.BRotation = 0;
            e.GRotation = 1;
            toRet.Add(e);

            return toRet;
        }

        public static IEnumerable<Piece> Game20()
        {
            var toRet = new List<Piece>();

            var k = new Gray().Shapes.ElementAt(0);
            k.RootPosition = new Location(0, 0, 0);
            k.ARotation = 0;
            k.BRotation = 0;
            k.GRotation = 0;
            toRet.Add(k);

            var d = new LightBlue().Shapes.ElementAt(0);
            d.RootPosition = new Location(5, 0, 0);
            d.ARotation = 0;
            d.BRotation = 2;
            d.GRotation = 1;
            toRet.Add(d);

            var j = new Peach().Shapes.ElementAt(0);
            j.RootPosition = new Location(3, 1, 0);
            j.ARotation = 0;
            j.BRotation = 2;
            j.GRotation = 1;
            toRet.Add(j);

            var a = new Lime().Shapes.ElementAt(0);
            a.RootPosition = new Location(3, 2, 0);
            a.ARotation = 0;
            a.BRotation = 2;
            a.GRotation = 1;
            toRet.Add(a);

            var g = new Green().Shapes.ElementAt(0);
            g.RootPosition = new Location(0, 5, 0);
            g.ARotation = 1;
            g.BRotation = 0;
            g.GRotation = 5;
            toRet.Add(g);

            var i = new Orange().Shapes.ElementAt(0);
            i.RootPosition = new Location(3, 1, 1);
            i.ARotation = 0;
            i.BRotation = 2;
            i.GRotation = 1;
            toRet.Add(i);

            var e = new Red().Shapes.ElementAt(0);
            e.RootPosition = new Location(0, 0, 1);
            e.ARotation = 2;
            e.BRotation = 0;
            e.GRotation = 1;
            toRet.Add(e);

            var c = new DarkBlue().Shapes.ElementAt(2);
            c.RootPosition = new Location(4, 0, 1);
            c.ARotation = 1;
            c.BRotation = 0;
            c.GRotation = 0;
            toRet.Add(c);

            return toRet;
        }

        public static IEnumerable<Piece> Game207()
        {
            var toRet = new List<Piece>();

            var k = new Gray().Shapes.ElementAt(0);
            k.RootPosition = new Location(0, 0, 0);
            k.ARotation = 0;
            k.BRotation = 0;
            k.GRotation = 0;
            toRet.Add(k);

            var d = new LightBlue().Shapes.ElementAt(0);
            d.RootPosition = new Location(5, 0, 0);
            d.ARotation = 0;
            d.BRotation = 2;
            d.GRotation = 1;
            toRet.Add(d);

            var j = new Peach().Shapes.ElementAt(0);
            j.RootPosition = new Location(3, 1, 0);
            j.ARotation = 0;
            j.BRotation = 2;
            j.GRotation = 1;
            toRet.Add(j);

            var a = new Lime().Shapes.ElementAt(0);
            a.RootPosition = new Location(3, 2, 0);
            a.ARotation = 0;
            a.BRotation = 2;
            a.GRotation = 1;
            toRet.Add(a);

            var g = new Green().Shapes.ElementAt(0);
            g.RootPosition = new Location(0, 5, 0);
            g.ARotation = 1;
            g.BRotation = 0;
            g.GRotation = 5;
            toRet.Add(g);

            var i = new Orange().Shapes.ElementAt(0);
            i.RootPosition = new Location(3, 1, 1);
            i.ARotation = 0;
            i.BRotation = 2;
            i.GRotation = 1;
            toRet.Add(i);

            var e = new Red().Shapes.ElementAt(0);
            e.RootPosition = new Location(0, 0, 1);
            e.ARotation = 2;
            e.BRotation = 0;
            e.GRotation = 1;
            toRet.Add(e);

            return toRet;
        }

        public static IEnumerable<Piece> Game206()
        {
            var toRet = new List<Piece>();

            var a = new Lime().Shapes.ElementAt(0);
            a.RootPosition = new Location(0, 0, 0);
            a.ARotation = 0;
            a.BRotation = 0;
            a.GRotation = 0;
            toRet.Add(a);

            var c = new DarkBlue().Shapes.ElementAt(0);
            c.RootPosition = new Location(3, 0, 0);
            c.ARotation = 0;
            c.BRotation = 0;
            c.GRotation = 1;
            toRet.Add(c);

            var i = new Orange().Shapes.ElementAt(0);
            i.RootPosition = new Location(0, 5, 0);
            i.ARotation = 0;
            i.BRotation = 0;
            i.GRotation = 4;
            toRet.Add(i);

            return toRet;
        }

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
            red.RootPosition = new Location(0, 3, 0);
            toRet.Add(red);

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

        public static IEnumerable<Piece> Game204()
        {
            var toRet = new List<Piece>();

            var white = new White().Shapes.ElementAt(0);
            white.RootPosition = new Location(0, 0, 0);
            toRet.Add(white);

            var orange = new Orange().Shapes.ElementAt(0);
            orange.BRotation = 2;
            orange.RootPosition = new Location(1, 2, 0);
            toRet.Add(orange);

            var green = new Green().Shapes.ElementAt(4);
            green.RootPosition = new Location(1, 1, 0);
            toRet.Add(green);

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

        public static IEnumerable<Piece> Game28()
        {
            var toRet = new List<Piece>();

            var orange = new Orange().Shapes.ElementAt(0);
            orange.RootPosition = new Location(1, 2, 0);
            orange.GRotation = 3;
            toRet.Add(orange);

            var purple = new Purple().Shapes.ElementAt(0);
            purple.RootPosition = new Location(3, 0, 0);
            purple.GRotation = 1;
            purple.BRotation = 2;
            toRet.Add(purple);

            var yellow = new Yellow().Shapes.ElementAt(0);
            yellow.RootPosition = new Location(2, 3, 0);
            yellow.GRotation = 3;
            yellow.BRotation = 2;
            toRet.Add(yellow);

            var lime = new Lime().Shapes.ElementAt(0);
            lime.RootPosition = new Location(2, 1, 0);
            lime.GRotation = 1;
            toRet.Add(lime);

            var green = new Green().Shapes.ElementAt(1);
            green.RootPosition = new Location(0, 2, 1);
            green.GRotation = 1;
            green.ARotation = 1;
            toRet.Add(green);

            var red = new Red().Shapes.ElementAt(0);
            red.RootPosition = new Location(3, 1, 1);
            red.GRotation = 2;
            toRet.Add(red);

            var pink = new Pink().Shapes.ElementAt(0);
            pink.RootPosition = new Location(0, 0, 1);
            toRet.Add(pink);

            return toRet;
        }

        public static IEnumerable<Piece> Game205()
        {
            var toRet = new List<Piece>();

            var a = new Lime().Shapes.ElementAt(0);
            a.RootPosition = new Location(0, 0, 0);
            a.ARotation = 0;
            a.BRotation = 0;
            a.GRotation = 0;
            toRet.Add(a);

            var b = new Yellow().Shapes.ElementAt(0);
            b.RootPosition = new Location(5, 0, 0);
            b.ARotation = 0;
            b.BRotation = 0;
            b.GRotation = 2;
            toRet.Add(b);

            var i = new Orange().Shapes.ElementAt(0);
            i.RootPosition = new Location(0, 0, 2);
            i.ARotation = 0;
            i.BRotation = 1;
            i.GRotation = 0;
            toRet.Add(i);

            return toRet;
        }
    }
}
