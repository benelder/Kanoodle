namespace Kanoodle.Core
{
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
                }, "Yellow 0", 'B'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0)
                }, "Yellow 1", 'B'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(0,1,0),
                    new Node(1,1,0),
                    new Node(2,1,0)
                }, "Yellow 2", 'B'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0)
                }, "Yellow 3", 'B')
            };
        }
    }
}

