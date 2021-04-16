namespace Kanoodle.Core
{
    public class Node
    {
        public Node(int a, int b, int g)
        {
            Offset = new Location() { A = a, B = b, G = g };
        }

        public Location Offset { get; set; }
        public override string ToString()
        {
            return Offset.ToString();
        }
    }
}

