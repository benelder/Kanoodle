using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
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
                    return new Location { A = -(location.B + location.G), B = location.A + location.B, G = location.G };
            
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

            var p = GetAbsolutePosition();

            return piece.GetAbsolutePosition().All(m => p.Any(n => n.Offset.Equals(m.Offset)));
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

    public class Color
    {
        public IEnumerable<Piece> Shapes { get; set; }
    }

    public class Gray : Color
    {
        public Gray()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Gray", 'K'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0)
                }, "Gray", 'K')
            };
        }
    }

    public class Red : Color
    {
        public Red()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Red", 'E'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0)
                }, "Red", 'E')
            };
        }
    }

    public class Pink : Color
    {
        public Pink()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(1,1,0)
                }, "Pink", 'F'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(2,-1,0)
                }, "Pink", 'F'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(-1,-1,0),
                    new Node(0,-1,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0)
                }, "Pink", 'F'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(-2,1,0),
                    new Node(-1,1,0),
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Pink", 'F')
            };
        }
    }

    public class Green : Color
    {
        public Green()
        {
            Shapes = new Piece[] {    //  0   0
                new Piece(new Node[] {// 0 0 0
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(2,1,0)
                }, "Green", 'G'),
                new Piece(new Node[] { // 0 0 0
                    new Node(0,0,0),   //  0   0
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,-1,0),
                    new Node(3,-1,0)
                }, "Green", 'G'),
                new Piece(new Node[] { // 0 0    
                    new Node(0,0,0),   //    0  
                    new Node(1,0,0),   //   0 0
                    new Node(0,1,0),
                    new Node(-1,2,0),
                    new Node(-2,2,0)
                }, "Green", 'G'),
                new Piece(new Node[] { //    0 0  
                    new Node(0,0,0),   //     0  
                    new Node(1,0,0),   //  0 0  
                    new Node(1,-1,0),  
                    new Node(1,-2,0),
                    new Node(0,-2,0)
                }, "Green", 'G'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0),
                    new Node(0,2,0)
                }, "Green", 'G'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(2,-2,0),
                    new Node(3,-2,0)
                }, "Green", 'G')
            };
        }

    }

    public class Purple : Color
    {
        public Purple()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,1,0)
                }, "Purple", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,-1,0)
                }, "Purple", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(0,1,0),
                    new Node(0,2,0)
                }, "Purple", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(2,-2,0)
                }, "Purple", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(-1,1,0),
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Purple", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(0,-1,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0)
                }, "Purple", 'L')
            };
        }
    }

    public class White : Color
    {
        public White()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(0,2,0)
                }, "White", 'H'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,-1,0),
                    new Node(2,-2,0)
                }, "White", 'H'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(0,1,0),
                    new Node(0,2,0),
                    new Node(1,1,0),
                    new Node(2,0,0)
                }, "White", 'H'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,-1,0),
                    new Node(2,-2,0),
                    new Node(2,-1,0),
                    new Node(2,0,0)
                }, "White", 'H')
            };
        }
    }

    public class Peach : Color
    {
        public Peach()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(2,1,0)
                }, "Peach", 'J'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0)
                }, "Peach", 'J')
            };
        }
    }

    public class Orange : Color
    {
        public Orange()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0)
                }, "Orange", 'I'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(3,-2,0)
                }, "Orange", 'I'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,1,0)
                }, "Orange", 'I'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,-1,0)
                }, "Orange", 'I')
            };
        }
    }

    public class LightBlue : Color
    {
        public LightBlue()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(0,1,0)
                }, "LightBlue", 'D'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(1,-1,0)
                }, "LightBlue", 'D'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(1,-2,0),
                    new Node(1,-3,0)
                }, "LightBlue", 'D'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(2,1,0)
                }, "LightBlue", 'D'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(3,-1,0)
                }, "LightBlue", 'D')
            };
        }
    }

    public class DarkBlue : Color
    {
        public DarkBlue()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,1,0),
                    new Node(2,2,0)
                }, "DarkBlue", 'C'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,-1,0),
                    new Node(4,-2,0)
                }, "DarkBlue", 'C')
            };
        }
    }

    public class Yellow : Color
    {
        public Yellow()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,1,0),
                    new Node(2,1,0)
                }, "Yellow", 'B'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0)
                }, "Yellow", 'B'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(0,1,0),
                    new Node(1,1,0),
                    new Node(2,1,0)
                }, "Yellow", 'B'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0)
                }, "Yellow", 'B')
            };
        }
    }

    public class Lime : Color
    {
        public Lime()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0),
                    new Node(2,1,0)
                }, "Lime", 'A'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0),
                    new Node(3,-2,0)
                }, "Lime", 'A'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(0,1,0),
                    new Node(-1,2,0),
                    new Node(-1,3,0)
                }, "Lime", 'A'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(1,-2,0),
                    new Node(2,-3,0)
                }, "Lime", 'A'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(3,-1,0)
                }, "Lime", 'A'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,-1,0),
                    new Node(2,1,0)
                }, "Lime", 'A')
            };
        }
    }
}

