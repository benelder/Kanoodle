namespace Kanoodle.Core
{
    public class LightBlue : Piece
    {
        public LightBlue() :
            base(new Node[] {
                    new Node(0,0,0),        //   0
                    new Node(1,0,0),        //  X 0 0 0
                    new Node(2,0,0),        //
                    new Node(3,0,0),        //
                    new Node(0,1,0)         //
                }, "LightBlue", 'D')
        { }
    }
}

