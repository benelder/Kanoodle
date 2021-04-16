namespace Kanoodle.Core
{
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
}

