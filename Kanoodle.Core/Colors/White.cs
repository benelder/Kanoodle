namespace Kanoodle.Core
{
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
}

