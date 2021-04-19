namespace Kanoodle.Core
{
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
                }, "Purple 0", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,-1,0)
                }, "Purple 1", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(0,1,0),
                    new Node(0,2,0)
                }, "Purple 2", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,-1,0),
                    new Node(2,-2,0)
                }, "Purple 3", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(-1,1,0),
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Purple 4", 'L'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(0,-1,0),
                    new Node(1,-1,0),
                    new Node(2,-1,0)
                }, "Purple 5", 'L')
            };
        }
    }
}

