namespace Kanoodle.Core
{
    public class Gray : Color
    {
        public Gray()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0), //  0 0
                    new Node(1,0,0), // X 0
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Gray 0", 'K'),
                new Piece(new Node[] {
                    new Node(0,0,0),  // X 0
                    new Node(1,0,0),  //  0 0
                    new Node(1,-1,0),
                    new Node(2,-1,0)
                }, "Gray 1", 'K'),
                new Piece(new Node[] {
                    new Node(0,0,0),  //   0
                    new Node(-1,1,0), //  0 0
                    new Node(-1,2,0), //   X
                    new Node(0,1,0)
                }, "Gray 2", 'K'),
                new Piece(new Node[] {
                    new Node(0,0,0),   //   X
                    new Node(0,-1,0),  //  0 0
                    new Node(-1,-1,0), //   0
                    new Node(1,-2,0)
                }, "Gray 3", 'K')
            };
        }
    }
}

