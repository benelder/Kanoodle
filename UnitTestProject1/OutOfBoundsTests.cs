using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class OutOfBoundsTests
    {
        [TestMethod]
        public void Gray_Bottom_Left()
        {
            var nodes = new Node[]
            {
                // gray piece
                new Node(0,0,0),
                new Node(1,0,0),
                new Node(0,1,0),
                new Node(1,1,0),
            };

            var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
            Assert.IsFalse(piece.IsOutOfBounds());
        }

        [TestMethod]
        public void Gray_300()
        {
            var nodes = new Node[]
            {
                // gray piece
                new Node(0,0,0),
                new Node(1,0,0),
                new Node(0,1,0),
                new Node(1,1,0),
            };

            var piece = new Piece(new Location() { A = 3, B = 0, G = 0 }, nodes);
            Assert.IsFalse(piece.IsOutOfBounds());
        }

        [TestMethod]
        public void Gray_300_Rotate_A()
        {
            var nodes = new Node[]
            {
                // gray piece
                new Node(0,0,0),
                new Node(1,0,0),
                new Node(0,1,0),
                new Node(1,1,0),
            };

            var piece = new Piece(new Location() { A = 3, B = 0, G = 0 }, nodes);
            piece.ARotation = 2;
            Assert.IsTrue(piece.IsOutOfBounds());
        }

        [TestMethod]
        public void Gray_000_Rotate_B1()
        {
            var nodes = new Node[]
            {
                // gray piece
                new Node(0,0,0),
                new Node(1,0,0),
                new Node(0,1,0),
                new Node(1,1,0),
            };

            var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
            piece.BRotation = 1;
            Assert.IsFalse(piece.IsOutOfBounds());
        }

        [TestMethod]
        public void Gray_000_Rotate_B2()
        {
            var nodes = new Node[]
            {
                // gray piece
                new Node(0,0,0),
                new Node(1,0,0),
                new Node(0,1,0),
                new Node(1,1,0),
            };

            var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
            piece.BRotation = 2;
            Assert.IsTrue(piece.IsOutOfBounds());
        }

        //[TestMethod]
        //public void Gray_000_Rotate_B1A1()
        //{
        //    var nodes = new Node[]
        //    {
        //        // gray piece
        //        new Node(0,0,0),
        //        new Node(1,0,0),
        //        new Node(0,1,0),
        //        new Node(1,1,0),
        //    };

        //    var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
        //    piece.BRotation = 1;
        //    piece.ARotation = 1;
        //    Assert.IsTrue(piece.IsOutOfBounds());
        //}
    }
}
