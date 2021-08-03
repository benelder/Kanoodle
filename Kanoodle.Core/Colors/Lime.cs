namespace Kanoodle.Core
{
    public class Lime : Piece
    {
        public Lime() :
            base(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0),
                    new Node(2,1,0)
                }, "Lime", 'A')
        { }
    }
}

