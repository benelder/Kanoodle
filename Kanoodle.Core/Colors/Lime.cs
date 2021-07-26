namespace Kanoodle.Core
{
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
                }, "Lime 0", 'A'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(3,-1,0),
                    new Node(3,-2,0)
                }, "Lime 1", 'A')
            };
        }
    }
}

