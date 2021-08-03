namespace Kanoodle.Core
{
    public class Red : Piece
    {
        public Red() : 
            base(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(1,1,0)
                }, "Red", 'E')
        { }
    }
}

