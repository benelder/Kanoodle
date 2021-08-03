namespace Kanoodle.Core
{
    public class Yellow : Piece
    {
        public Yellow() :
            base(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,1,0),
                    new Node(2,1,0)
                }, "Yellow", 'B')
        { }
    }
}

