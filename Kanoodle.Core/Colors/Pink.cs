namespace Kanoodle.Core
{
    public class Pink : Piece
    {
        public Pink() :
            base(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(1,1,0)
                }, "Pink", 'F')
        { }
    }
}

