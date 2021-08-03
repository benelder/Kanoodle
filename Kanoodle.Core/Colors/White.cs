namespace Kanoodle.Core
{
    public class White : Piece
    {
        public White() :
            base(new Node[] {
                    new Node(0,0,0),   //   0  
                    new Node(1,0,0),   //  0  
                    new Node(2,0,0),   // X 0 0
                    new Node(0,1,0),
                    new Node(0,2,0)
                }, "White", 'H')
        { }
    }
}

