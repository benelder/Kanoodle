using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Piece
    {
        public Piece(Location rootPosition, Node[] nodes)
        {
            RootPosition = rootPosition;
            GRotation = 0;
            ARotation = 0;
            BRotation = 0;
            Nodes = nodes;
        }

        public Piece(Node[] nodes)
        {
            RootPosition = new Location(0, 0, 0);
            GRotation = 0;
            ARotation = 0;
            BRotation = 0;
            Nodes = nodes;
        }

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
                    var offset = RotateB(RotateA(RotateG(Nodes[i].Offset)));

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

        private Location RotateG(Location location)
        {
            if (GRotation == 0)
                return location;

            if (GRotation == 1)
                return new Location { A = -location.B, B = location.A + location.B, G = location.G };

            if (GRotation == 2)
                return new Location { A = -(location.A + location.B), B = location.A, G = location.G };

            if (GRotation == 3)
                return new Location { A = -location.A, B = -location.B, G = location.G };

            if (GRotation == 4)
                return new Location { A = location.B, B = -(location.A + location.B), G = location.G };

            if (GRotation == 5)
                return new Location { A = location.A + location.B, B = -location.A, G = location.G };

            throw new Exception("invalid GRotation");
        }

        private Location RotateA(Location location)
        {
            if (ARotation == 0)
                return location;

            if (ARotation == 1)
                return new Location { A = location.A, B = -location.G, G = location.B + location.G };

            if (ARotation == 2)
                return new Location { A = location.A + location.G, B = -(location.B + location.G), G = location.B };


            throw new Exception("invalid ARotation");
        }

        private Location RotateB(Location location)
        {
            if (BRotation == 0)
                return location;

            if (BRotation == 1)
                return new Location { A = -location.G, B = location.B, G = location.A + location.G };

            if (BRotation == 2)
                return new Location { A = -(location.A + location.G), B = location.B, G = location.A };

            throw new Exception("invalid BRotation");
        }
    }

    public struct Location
    {
        public Location(int a, int b, int g)
        {
            A = a;
            B = b;
            G = g;
        }
        public int A { get; set; }
        public int B { get; set; }
        public int G { get; set; }
        public override string ToString()
        {
            return $"{{{A}, {B}, {G}}}";
        }
    }

    public class Node
    {
        public Node(int a, int b, int g)
        {
            Offset = new Location() { A = a, B = b, G = g };
        }

        public Location Offset { get; set; }
        public override string ToString()
        {
            return Offset.ToString();
        }
    }

    public class Gray : Piece
    {
        public Gray() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(0,1,0),
            new Node(1,1,0)
        })
        {
            Name = "Gray";
            Character = 'K';
        }
    }

    public class Red : Piece
    {
        public Red() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(0,1,0),
            new Node(1,1,0)
        })
        {
            Name = "Red";
            Character = 'E';
        }
    }

    public class Pink : Piece
    {
        public Pink() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(3,0,0),
            new Node(1,1,0)
        })
        {
            Name = "Pink";
            Character = 'F';
        }
    }

    public class Green : Piece
    {
        public Green() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(0,1,0),
            new Node(2,1,0)
        })
        {
            Name = "Green";
            Character = 'G';
        }
    }

    public class Purple : Piece
    {
        public Purple() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(1,1,0)
        })
        {
            Name = "Purple";
            Character = 'L';
        }
    }

    public class White : Piece
    {
        public White() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(0,1,0),
            new Node(0,2,0)
        })
        {
            Name = "White";
            Character = 'H';
        }
    }

    public class Peach : Piece
    {
        public Peach() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(1,1,0),
            new Node(2,1,0)
        })
        {
            Name = "Peach";
            Character = 'J';
        }
    }

    public class Orange : Piece
    {
        public Orange() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(1,1,0),
            new Node(1,2,0)
        })
        {
            Name = "Orange";
            Character = 'B';
        }
    }

    public class LightBlue : Piece
    {
        public LightBlue() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(3,0,0),
            new Node(0,1,0)
        })
        {
            Name = "LightBlue";
            Character = 'D';
        }
    }

    public class DarkBlue : Piece
    {
        public DarkBlue() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(2,1,0),
            new Node(2,2,0)
        })
        {
            Name = "DarkBlue";
            Character = 'C';
        }
    }

    public class Yellow : Piece
    {
        public Yellow() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(2,0,0),
            new Node(1,1,0),
            new Node(2,1,0)
        })
        {
            Name = "Yellow";
            Character = 'B';
        }
    }

    public class Lime : Piece
    {
        public Lime() : base(new Node[] {
            new Node(0,0,0),
            new Node(1,0,0),
            new Node(1,1,0),
            new Node(1,2,0),
            new Node(2,1,0)
        })
        {
            Name = "Lime";
            Character = 'A';
        }
    }
}

