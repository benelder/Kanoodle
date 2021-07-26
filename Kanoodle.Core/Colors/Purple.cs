namespace Kanoodle.Core
{
    public class Purple : Color
    {
        public Purple()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {    //
                    new Node(0,0,0),      //
                    new Node(1,0,0),      //     0
                    new Node(2,0,0),      //  X 0 0
                    new Node(1,1,0)       //   
                }, "Purple 0", 'L'),      //
                new Piece(new Node[] {    //
                    new Node(0,0,0),      //  X 0 0
                    new Node(1,0,0),      //     0
                    new Node(2,0,0),      //  
                    new Node(2,-1,0)      //
                }, "Purple 1", 'L')
            };
        }
    }
}

