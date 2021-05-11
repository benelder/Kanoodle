namespace Kanoodle.Core
{
    public class DarkBlue : Color
    {
        public DarkBlue()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {  //       0
                    new Node(0,0,0),    //      0      
                    new Node(1,0,0),    // X 0 0
                    new Node(2,0,0),
                    new Node(2,1,0),
                    new Node(2,2,0)
                }, "DarkBlue 0", 'C'),
                new Piece(new Node[] {
                    new Node(0,0,0),    // 0 0 0
                    new Node(1,0,0),    //      0
                    new Node(2,0,0),    //       0
                    new Node(3,-1,0),   
                    new Node(4,-2,0)
                }, "DarkBlue 1", 'C')
            };
        }
    }
}

