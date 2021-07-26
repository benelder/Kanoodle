namespace Kanoodle.Core
{
    public class Pink : Color
    {
        public Pink()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,0,0),
                    new Node(1,1,0)
                }, "Pink 0", 'F')
            };
        }
    }
}

