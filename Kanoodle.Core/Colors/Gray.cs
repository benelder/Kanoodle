namespace Kanoodle.Core
{
    public class Gray : Piece
    {
        public Gray() :
            base(new Node[] {
                    new Node(0,0,0), //  0 0
                    new Node(1,0,0), // X 0
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Gray", 'K')
        { }
    }
}

