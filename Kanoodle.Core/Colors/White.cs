namespace Kanoodle.Core
{
    public class White : Color
    {
        public White()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),   //   0  
                    new Node(1,0,0),   //  0  
                    new Node(2,0,0),   // X 0 0
                    new Node(0,1,0),
                    new Node(0,2,0)
                }, "White 0", 'H')
            };
        }
    }
}

