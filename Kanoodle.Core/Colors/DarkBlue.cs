namespace Kanoodle.Core
{
    public class DarkBlue : Piece
    {
        public DarkBlue() : 
            base(new Node[] {       //       0
                new Node(0,0,0),    //      0      
                new Node(1,0,0),    // X 0 0
                new Node(2,0,0),
                new Node(2,1,0),
                new Node(2,2,0)
            }, "DarkBlue", 'C')
        { }
    }
}

