using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GRotationTests
    {
        [TestMethod]
        public void RotateG_1_Gray()
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
            piece.GRotation = 1;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(0, 1, 0), abs[1].Offset);
            Assert.AreEqual(new Location(-1, 1, 0), abs[2].Offset);
            Assert.AreEqual(new Location(-1, 2, 0), abs[3].Offset);
        }

        [TestMethod]
        public void RotateG_2_Gray()
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
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(-1, 1, 0), abs[1].Offset);
            Assert.AreEqual(new Location(-1, 0, 0), abs[2].Offset);
            Assert.AreEqual(new Location(-2, 1, 0), abs[3].Offset);
        }

        //[TestMethod]
        //public void RotateG_3_Gray()
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
        //    piece.GRotation = 3;
        //    var abs = piece.GetAbsolutePosition();

        //    Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
        //    Assert.AreEqual(new Location(-1, 0, 0), abs[1].Offset);
        //    Assert.AreEqual(new Location(0, -1, 0), abs[2].Offset);
        //    Assert.AreEqual(new Location(-1, -1, 0), abs[3].Offset);
        //}

        //[TestMethod]
        //public void RotateG_4_Gray()
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
        //    piece.GRotation = 4;
        //    var abs = piece.GetAbsolutePosition();

        //    Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
        //    Assert.AreEqual(new Location(0, -1, 0), abs[1].Offset);
        //    Assert.AreEqual(new Location(1, -1, 0), abs[2].Offset);
        //    Assert.AreEqual(new Location(1, -2, 0), abs[3].Offset);
        //}

        //[TestMethod]
        //public void RotateG_5_Gray()
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
        //    piece.GRotation = 5;
        //    var abs = piece.GetAbsolutePosition();

        //    Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
        //    Assert.AreEqual(new Location(1, -1, 0), abs[1].Offset);
        //    Assert.AreEqual(new Location(1, 0, 0), abs[2].Offset);
        //    Assert.AreEqual(new Location(2, -1, 0), abs[3].Offset);
        //}


        /// <summary>
        /// DARK BLUE 
        /// </summary>
        [TestMethod]
        public void RotateG_1_DarkBlue()
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
            piece.GRotation = 1;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(0, 1, 0), abs[1].Offset);
            Assert.AreEqual(new Location(0, 2, 0), abs[2].Offset);
            Assert.AreEqual(new Location(-1, 3, 0), abs[3].Offset);
            Assert.AreEqual(new Location(-2, 4, 0), abs[4].Offset);
        }

        [TestMethod]
        public void RotateG_2_DarkBlue()
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
            piece.GRotation = 2;
            var abs = piece.GetAbsolutePosition();

            Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
            Assert.AreEqual(new Location(-1, 1, 0), abs[1].Offset);
            Assert.AreEqual(new Location(-2, 2, 0), abs[2].Offset);
            Assert.AreEqual(new Location(-3, 2, 0), abs[3].Offset);
            Assert.AreEqual(new Location(-4, 2, 0), abs[4].Offset);
        }

        //[TestMethod]
        //public void RotateG_3_DarkBlue()
        //{
        //    var nodes = new Node[]
        //    {
        //        new Node(0,0,0),
        //        new Node(1,0,0),
        //        new Node(2,0,0),
        //        new Node(2,1,0),
        //        new Node(2,2,0),
        //    };

        //    var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
        //    piece.GRotation = 3;
        //    var abs = piece.GetAbsolutePosition();

        //    Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
        //    Assert.AreEqual(new Location(-1, 0, 0), abs[1].Offset);
        //    Assert.AreEqual(new Location(-2, 0, 0), abs[2].Offset);
        //    Assert.AreEqual(new Location(-2, -1, 0), abs[3].Offset);
        //    Assert.AreEqual(new Location(-2, -2, 0), abs[4].Offset);
        //}

        //[TestMethod]
        //public void RotateG_4_DarkBlue()
        //{
        //    var nodes = new Node[]
        //    {
        //        new Node(0,0,0),
        //        new Node(1,0,0),
        //        new Node(2,0,0),
        //        new Node(2,1,0),
        //        new Node(2,2,0),
        //    };

        //    var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
        //    piece.GRotation = 4;
        //    var abs = piece.GetAbsolutePosition();

        //    Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
        //    Assert.AreEqual(new Location(0, -1, 0), abs[1].Offset);
        //    Assert.AreEqual(new Location(0, -2, 0), abs[2].Offset);
        //    Assert.AreEqual(new Location(1, -3, 0), abs[3].Offset);
        //    Assert.AreEqual(new Location(2, -4, 0), abs[4].Offset);
        //}

        //[TestMethod]
        //public void RotateG_5_DarkBlue()
        //{
        //    var nodes = new Node[]
        //    {
        //        new Node(0,0,0),
        //        new Node(1,0,0),
        //        new Node(2,0,0),
        //        new Node(2,1,0),
        //        new Node(2,2,0),
        //    };

        //    var piece = new Piece(new Location() { A = 0, B = 0, G = 0 }, nodes);
        //    piece.GRotation = 5;
        //    var abs = piece.GetAbsolutePosition();

        //    Assert.AreEqual(new Location(0, 0, 0), abs[0].Offset);
        //    Assert.AreEqual(new Location(1, -1, 0), abs[1].Offset);
        //    Assert.AreEqual(new Location(2, -2, 0), abs[2].Offset);
        //    Assert.AreEqual(new Location(3, -2, 0), abs[3].Offset);
        //    Assert.AreEqual(new Location(4, -2, 0), abs[4].Offset);
        //}
    }
}
