using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanoodle.Core
{
    public class Piece
    {
        public Piece(Location rootPosition, Node[] nodes, string name, char character)
        {
            RootPosition = rootPosition;
            GRotation = 0;
            ARotation = 0;
            BRotation = 0;
            Nodes = nodes;
            Name = name;
            Character = character;
        }

        public override string ToString()
        {
            return $"{Name} / {RootPosition} / G:{GRotation} A:{ARotation} B:{BRotation}";
        }

        public Piece(Node[] nodes, string name, char character) : this(new Location(0, 0, 0), nodes, name, character) { }

        public string Name { get; set; }
        public char Character { get; set; }
        public Location RootPosition { get; set; }
        public int GRotation { get; set; }
        public int ARotation { get; set; }
        public int BRotation { get; set; }
        public Node[] Nodes { get; set; }

        public string AbsId()
        {
            return $"{Character}{RootPosition.A}{RootPosition.B}{RootPosition.G}{ARotation}{BRotation}{GRotation}";
        }

        private Node[] _absolutePosition;
        public Node[] GetAbsolutePosition()
        {
            if (_absolutePosition == null)
            {
                var toRet = new List<Node>();

                for (int i = 0; i < Nodes.Length; i++)
                {
                    if (BRotation != 0 && ARotation != 0)
                        throw new Exception("invalid rotation sequence. either A or B must be zero");
                    
                    var offB = RotateB(Nodes[i].Offset);
                    var offA = RotateA(offB);
                    var offset = RotateG(offA);

                    var toAdd = new Node(RootPosition.A + offset.A,
                        RootPosition.B + offset.B,
                        RootPosition.G + offset.G);

                    toRet.Add(toAdd);
                }
                _absolutePosition = toRet.ToArray();
            }

            return _absolutePosition;
        }

        public bool IsOutOfBounds()
        {
            var abs = GetAbsolutePosition();
            if (abs.Any(m => m.Offset.G < 0))
                return true;

            if (abs.Any(m => m.Offset.A < 0))
                return true;

            if (abs.Any(m => m.Offset.B < 0))
                return true;

            if (abs.Any(m => m.Offset.A + m.Offset.B + m.Offset.G > 5))
                return true;

            return false;
        }

        private Location RotateG(Location location) // todo: test all this logic extensively
        {
            if (GRotation == 0)
                return location;

            if (GRotation == 1)
                    return new Location { A = -location.B, B = location.A + location.B, G = location.G };
            
            if (GRotation == 2)
                return new Location { A = -(location.A + location.B + location.G), B = location.A, G = location.G };

            if (GRotation == 3)
                return new Location { A = -location.A, B = -(location.B + location.G), G = location.G };

            if (GRotation == 4)
                return new Location { A = location.B, B = -(location.A + location.B+ location.G), G = location.G };

            if (GRotation == 5)
                return new Location { A = location.A + location.B, B = -(location.A + location.G), G = location.G };

            throw new Exception("invalid GRotation");
        }

        private Location RotateA(Location location)
        {
            if (ARotation == 0)
                return location;

            if (ARotation == 1)
                return new Location { A = location.A, B = 0, G = location.B };

            // not valid if we rotate G -> A , since G will allways be zero
            //if (ARotation == 1)
            //    return new Location { A = location.A, B = -location.G, G = location.B + location.G };

            if (ARotation == 2)
                return new Location { A = location.A + location.B, B = -location.B, G = 0 };

            // not valid if we rotate G -> A , since G will allways be zero
            //if (ARotation == 1)
            //    return new Location { A = location.A + location.B + location.G, B = -location.B, G = -(location.B + location.G) };


            throw new Exception("invalid ARotation");
        }

        private Location RotateB(Location location)
        {
            if (BRotation == 0)
                return location;

            if (BRotation == 1)
                return new Location { A = 0, B = location.B, G = location.A };

            if (BRotation == 2)
                return new Location { A = -location.A, B = location.B + location.A, G = 0 };

            throw new Exception("invalid BRotation");
        }

        public bool IsInSamePositionAs(Piece piece)
        {
            if (piece.Nodes.Count() != this.Nodes.Count())
                return false; // not same shape

            var t = GetAbsolutePosition();

            var p = piece.GetAbsolutePosition();

            for (int i = 0; i < t.Length; i++)
            {
                var nodeMatch = false;
                for (int j = 0; j < p.Length; j++)
                {
                    if (t[i].Offset.Equals(p[j].Offset))
                    {
                        nodeMatch = true;
                        break;
                    }
                }
                if (!nodeMatch) return false;
            }

            return true;
        }
    }
}

