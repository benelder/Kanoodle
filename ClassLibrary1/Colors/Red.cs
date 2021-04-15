namespace Kanoodle.Core
{
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
}

