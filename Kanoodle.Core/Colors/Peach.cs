namespace Kanoodle.Core
{
    public class Peach : Piece
    {
        public Peach() :
            base(new Node[] {           //     0 0
                    new Node(0,0,0),    //  X 0
                    new Node(1,0,0),    
                    new Node(1,1,0),     
                    new Node(2,1,0)      
                }, "Peach", 'J')
        { }
    }
}

