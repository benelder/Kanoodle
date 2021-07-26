using System;
using System.Linq;
using Xunit;

namespace Kanoodle.Core.Test
{
    /// <summary>
    /// Asserting GetAbsolutionPosition results are as expected. Test names follow <color>_<root_position>_<plane>_<rotation>_<lean>
    /// </summary>
    public class Red_Plane_1_Tests
    {
        [Fact]
        public void Red_410_0_0_0()
        {
            var color = new Red();
            var piece = color.Shapes.ElementAt(0);
            piece.RootPosition = new Location(4, 1, 0);
            piece.Plane = 0;
            piece.Rotation = 0;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(4, 1, 0), result);
            Assert.Contains(new Node(4, 2, 0), result);
            Assert.Contains(new Node(5, 1, 0), result);
            Assert.Contains(new Node(5, 2, 0), result);
            Assert.Contains(new Node(6, 1, 0), result);

        }

        [Fact]
        public void Red_410_0_2_0()
        {
            var color = new Red();
            var piece = color.Shapes.ElementAt(0);
            piece.RootPosition = new Location(4, 1, 0);
            piece.Plane = 0;
            piece.Rotation = 2;
            piece.Lean = false;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
            Assert.Contains(new Node(2, 2, 0), result);
            Assert.Contains(new Node(2, 3, 0), result);
            Assert.Contains(new Node(3, 2, 0), result);

        }

        [Fact]
        public void Red_410_0_2_1()
        {
            var color = new Red();
            var piece = color.Shapes.ElementAt(0);
            piece.RootPosition = new Location(4, 1, 0);
            piece.Plane = 0;
            piece.Rotation = 2;
            piece.Lean = true;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(3, 1, 0), result);
            Assert.Contains(new Node(4, 1, 0), result);
            Assert.Contains(new Node(2, 1, 1), result);
            Assert.Contains(new Node(3, 1, 1), result);
            Assert.Contains(new Node(2, 1, 2), result);
        }

        [Fact]
        public void Red_410_1_2_1()
        {
            var color = new Red();
            var piece = color.Shapes.ElementAt(0);
            piece.RootPosition = new Location(4, 1, 0);
            piece.Plane = 1;
            piece.Rotation = 2;
            piece.Lean = true;
            var result = piece.GetAbsolutePosition();
            Assert.Contains(new Node(0, 4, 0), result);
            Assert.Contains(new Node(1, 3, 0), result);
            Assert.Contains(new Node(1, 2, 1), result);
            Assert.Contains(new Node(0, 3, 1), result);
            Assert.Contains(new Node(0, 2, 2), result);
            Assert.False(piece.IsOutOfBounds());
        }
    }
}
