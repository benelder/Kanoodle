using System;
using System.Linq;
using Xunit;

namespace Kanoodle.Core.Test
{
    /// <summary>
    /// Asserting GetAbsolutionPosition results are as expected. Test names follow <color>_<root_position>_<plane>_<rotation>_<lean>
    /// </summary>
    public class Purple_Plane_0_Tests
    {
        [Fact]
        public void Purple_000_0_0_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(0, 0, 0);
            piece.Plane = 0;
            piece.Rotation = 0;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(0, 0, 0), result);
            Assert.Contains(new Node(1, 0, 0), result);
            Assert.Contains(new Node(2, 0, 0), result);
            Assert.Contains(new Node(1, 1, 0), result);
        }

        [Fact]
        public void Purple_100_0_1_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(1, 0, 0);
            piece.Plane = 0;
            piece.Rotation = 1;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(1, 0, 0), result);
            Assert.Contains(new Node(1, 1, 0), result);
            Assert.Contains(new Node(1, 2, 0), result);
            Assert.Contains(new Node(0, 2, 0), result);
        }

        [Fact]
        public void Purple_500_0_2_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(5, 0, 0);
            piece.Plane = 0;
            piece.Rotation = 2;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(5, 0, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(3, 2, 0), result);
        }

        [Fact]
        public void Purple_210_0_3_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(2, 1, 0);
            piece.Plane = 0;
            piece.Rotation = 3;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(1, 0, 0), result);
            Assert.Contains(new Node(0, 1, 0), result);
            Assert.Contains(new Node(1, 1, 0), result);
            Assert.Contains(new Node(2, 1, 0), result);
        }

        [Fact]
        public void Purple_020_0_4_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(0, 2, 0);
            piece.Plane = 0;
            piece.Rotation = 4;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(0, 0, 0), result);
            Assert.Contains(new Node(0, 1, 0), result);
            Assert.Contains(new Node(0, 2, 0), result);
            Assert.Contains(new Node(1, 0, 0), result);
        }

        [Fact]
        public void Purple_020_0_5_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(0, 2, 0);
            piece.Plane = 0;
            piece.Rotation = 5;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(2, 0, 0), result);
            Assert.Contains(new Node(1, 1, 0), result);
            Assert.Contains(new Node(2, 1, 0), result);
            Assert.Contains(new Node(0, 2, 0), result);
        }
    }
}
