using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MultiRotationTests
    {
        [TestMethod]
        public void RotateGrayG2A1()
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
            piece.GRotation = 2;
            piece.ARotation = 1;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(-1, 0, 1), abs[1].Offset);
            Assert.AreEqual(new Location(-1, 0, 0), abs[2].Offset);
            Assert.AreEqual(new Location(-2, 0, 1), abs[3].Offset);
        }

        [TestMethod]
        public void RotateGrayA1B1()
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
            piece.ARotation = 1;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(0, 0, 1), abs[1].Offset);
            Assert.AreEqual(new Location(-1, 0, 1), abs[2].Offset);
            Assert.AreEqual(new Location(-1, 0, 2), abs[3].Offset);
        }

        [TestMethod]
        public void RotateGrayG2A2B1()
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
            piece.GRotation = 2;
            piece.BRotation = 2;
            piece.ARotation = 1;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(0, 0, -1), abs[1].Offset);
            Assert.AreEqual(new Location(1, 0, -1), abs[2].Offset);
            Assert.AreEqual(new Location(1, 0, -2), abs[3].Offset);
        }

        [TestMethod]
        public void RotateGrayG4B1()
        {
            var nodes = new Node[]
            {
                new Node(0,0,0),
                new Node(1,0,0),
                new Node(2,0,0),
                new Node(2,1,0),
                new Node(2,2,0),
            };

            var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
            piece.GRotation = 4;
            piece.BRotation = 1;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(0, -1, 0), abs[1].Offset);
            Assert.AreEqual(new Location(0, -2, 0), abs[2].Offset);
            Assert.AreEqual(new Location(0, -3, 1), abs[3].Offset);
            Assert.AreEqual(new Location(0, -4, 2), abs[4].Offset);
        }
    }
}
