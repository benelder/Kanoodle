namespace Kanoodle.Core
{
    public class Purple : Piece
    {
        public Purple() :
            base(new Node[] {           //
                    new Node(0,0,0),    //
                    new Node(1,0,0),    //     0
                    new Node(2,0,0),    //  X 0 0
                    new Node(1,1,0)     //   
                }, "Purple", 'L')
        { }
    }
}

