using System;
using System.Linq;
using Xunit;

namespace Kanoodle.Core.Test
{
    /// <summary>
    /// Asserting GetAbsolutionPosition results are as expected. Test names follow <color>_<root_position>_<plane>_<rotation>_<lean>
    /// </summary>
    public class Purple_Plane_1_Tests
    {
        [Fact]
        public void Purple_000_1_0_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(0, 0, 0);
            piece.Plane = 1;
            piece.Rotation = 0;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(5, 0, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(3, 2, 0), result);
        }

        [Fact]
        public void Purple_100_1_1_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(1, 0, 0);
            piece.Plane = 1;
            piece.Rotation = 1;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(3, 0, 0), result);
            Assert.Contains(new Node(2, 1, 0), result);
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
        }

        [Fact]
        public void Purple_500_1_2_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(5, 0, 0);
            piece.Plane = 1;
            piece.Rotation = 2;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(0, 3, 0), result);
            Assert.Contains(new Node(0, 4, 0), result);
            Assert.Contains(new Node(0, 5, 0), result);
            Assert.Contains(new Node(1, 3, 0), result);
        }

        [Fact]
        public void Purple_210_1_3_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(2, 1, 0);
            piece.Plane = 1;
            piece.Rotation = 3;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(4, 0, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(2, 2, 0), result);
        }

        [Fact]
        public void Purple_020_1_4_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(0, 2, 0);
            piece.Plane = 1;
            piece.Rotation = 4;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(3, 0, 0), result);
            Assert.Contains(new Node(4, 0, 0), result);
            Assert.Contains(new Node(5, 0, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
        }

        [Fact]
        public void Purple_020_1_5_0()
        {
            var piece = new Purple();
            piece.RootPosition = new Location(0, 2, 0);
            piece.Plane = 1;
            piece.Rotation = 5;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(3, 0, 0), result);
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(3, 2, 0), result);
            Assert.Contains(new Node(2, 2, 0), result);
        }
    }
}
