namespace Kanoodle.Core
{
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
}

