namespace Kanoodle.Core
{
    public class Orange : Color
    {
        public Orange()
        {
            Shapes = new Piece[] {
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0)
                }, "Orange 0", 'I'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(3,-2,0)
                }, "Orange 1", 'I'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(2,1,0)
                }, "Orange 2", 'I'),
                 new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(3,-1,0)
                }, "Orange 3", 'I')
            };
        }
    }
}

