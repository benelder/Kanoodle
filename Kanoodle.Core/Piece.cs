using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanoodle.Core
{
    public class Piece
    {
        public Piece(Location rootPosition, Node[] nodes, string name, char character) : this(rootPosition, 0, 0, false, nodes, name, character) { }

        public Piece(Location rootPosition, int rotation, int plane, bool lean, Node[] nodes, string name, char character)
        {
            RootPosition = rootPosition;
            Rotation = rotation;
            Plane = plane;
            Nodes = nodes;
            Name = name;
            Character = character;
        }

        public override string ToString()
        {
            return $"{Name} / {RootPosition} / P:{Plane} R:{Rotation}";
        }

        public Piece(Node[] nodes, string name, char character) : this(new Location(0, 0, 0), nodes, name, character) { }

        public string Name { get; set; }
        public char Character { get; set; }

        private Location _rootPosition;
        public Location RootPosition { get { return _rootPosition; } set { _absolutePosition = null; _rootPosition = value; } }

        public int _plane { get; set; }
        public int Plane { get { return _plane; } set { _absolutePosition = null; _plane = value; } }

        public bool _lean { get; set; }
        public bool Lean { get { return _lean; } set { _absolutePosition = null; _lean = value; } }

        private int _rotation;
        public int Rotation { get { return _rotation; } set { _absolutePosition = null; _rotation = value; } }

        public Node[] Nodes { get; set; }

        public string AbsId()
        {
            return $"{Character}{RootPosition.X}{RootPosition.Y}{RootPosition.Z}{Plane}{Rotation}";
        }

        private Node[] _absolutePosition;
        public Node[] GetAbsolutePosition()
        {
            if (_absolutePosition == null)
            {
                var toRet = new List<Node>();

                for (int i = 0; i < Nodes.Length; i++)
                {
                    var offset = Rotate(Nodes[i].Offset);
                    var lean = ApplyLean(offset);

                    var origin = new Location(RootPosition.X + lean.X,
                        RootPosition.Y + lean.Y,
                        RootPosition.Z + lean.Z);

                    var transpose = TransposeToPlane(origin);
                    
                    toRet.Add(new Node(transpose.X, transpose.Y, transpose.Z));
                }
                _absolutePosition = toRet.ToArray();
            }

            return _absolutePosition;
        }

        private Location ApplyLean(Location offset)
        {
            if (Lean)
            {
                return new Location { X = offset.X, Y = 0, Z = offset.Y };
            }
            else
            {
                return offset;
            }
        }

        private Location TransposeToPlane(Location origin)
        {
            if (Plane == 0)
            {
                return origin; // transposition is based on Plane 0, so no change if Plane == 0
            }

            else if (Plane == 1)
            {
                return new Location { X = 5 - (origin.X + origin.Y + origin.Z), Y = origin.X, Z = origin.Z };
            }

            else if (Plane == 2)
            {
                return new Location { X = origin.Y, Y = 5 - (origin.X + origin.Y + origin.Z), Z = origin.Z };
            }

            throw new Exception("Plane must be between 0 and 2");
        }

        public bool IsOutOfBounds()
        {
            var abs = GetAbsolutePosition();
            if (abs.Any(m => m.Offset.Z < 0))
                return true;

            if (abs.Any(m => m.Offset.X < 0))
                return true;

            if (abs.Any(m => m.Offset.Y < 0))
                return true;

            if (abs.Any(m => m.Offset.X + m.Offset.Y + m.Offset.Z > 5))
                return true;

            return false;
        }

        private Location Rotate(Location location) // todo: test all this logic extensively
        {
            if (Rotation == 0)
                return location;

            if (Rotation == 1)
                return new Location { X = -location.Y, Y = location.X + location.Y, Z = location.Z };

            if (Rotation == 2)
                return new Location { X = -(location.X + location.Y + location.Z), Y = location.X, Z = location.Z };

            if (Rotation == 3)
                return new Location { X = -location.X, Y = -(location.Y + location.Z), Z = location.Z };

            if (Rotation == 4)
                return new Location { X = location.Y, Y = -(location.X + location.Y + location.Z), Z = location.Z };

            if (Rotation == 5)
                return new Location { X = location.X + location.Y, Y = -(location.X + location.Z), Z = location.Z };

            throw new Exception("invalid GRotation");
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

