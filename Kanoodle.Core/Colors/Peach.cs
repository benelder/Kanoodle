namespace Kanoodle.Core
{
    public class Peach : Color
    {
        public Peach()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {   //     0 0
                    new Node(0,0,0),     //  X 0
                    new Node(1,0,0),     //
                    new Node(1,1,0),     //
                    new Node(2,1,0)      //
                }, "Peach 0", 'J'),     
                new Piece(new Node[] {   //
                    new Node(0,0,0),     //     
                    new Node(1,0,0),     //  X 0
                    new Node(2,-1,0),    //     0 0
                    new Node(3,-1,0)     //
                }, "Peach 1", 'J'),
                 new Piece(new Node[] {  // 100% dupe
                    new Node(0,0,0),     //     
                    new Node(1,0,0),     //  0 0
                    new Node(-1,1,0),    //     X 0
                    new Node(-2,1,0)     //
                }, "Peach 2", 'J')       //
            };
        }
    }
}

