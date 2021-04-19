namespace Kanoodle.Core
{
    public class Green : Color
    {
        public Green()
        {
            Shapes = new Piece[] {    //  0   0
                new Piece(new Node[] {// 0 0 0
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(0,1,0),
                    new Node(2,1,0)
                }, "Green 0", 'G'),
                new Piece(new Node[] { // 0 0 0
                    new Node(0,0,0),   //  0   0
                    new Node(1,0,0),
                    new Node(2,0,0),
                    new Node(1,-1,0),
                    new Node(3,-1,0)
                }, "Green 1", 'G'),
                new Piece(new Node[] { // 0 0    
                    new Node(0,0,0),   //    0  
                    new Node(1,0,0),   //   0 0
                    new Node(0,1,0),
                    new Node(-1,2,0),
                    new Node(-2,2,0)
                }, "Green 2", 'G'),
                new Piece(new Node[] { //    0 0  
                    new Node(0,0,0),   //     0  
                    new Node(1,0,0),   //  0 0  
                    new Node(1,-1,0),  
                    new Node(1,-2,0),
                    new Node(0,-2,0)
                }, "Green 3", 'G'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(1,1,0),
                    new Node(1,2,0),
                    new Node(0,2,0)
                }, "Green 4", 'G'),
                new Piece(new Node[] {
                    new Node(0,0,0),
                    new Node(1,0,0),
                    new Node(2,-1,0),
                    new Node(2,-2,0),
                    new Node(3,-2,0)
                }, "Green 5", 'G')
            };
        }

    }
}

