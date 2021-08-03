namespace Kanoodle.Core
{
    public class Orange : Piece
    {
        public Orange() :
            base(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0)
                }, "Orange", 'I')
        { }
    }
}

