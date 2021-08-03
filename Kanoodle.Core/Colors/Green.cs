namespace Kanoodle.Core
{
    public class Green : Piece
    {
        public Green() : 
            base(new Node[] {           //  0   0
                    new Node(0,0,0),    // X 0 0
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(2,1,0)
                }, "Green", 'G')
        { }
    }
}

