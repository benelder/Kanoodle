namespace Kanoodle.Core
{
    public struct Node
    {
        public Node(int x, int y, int z)
        {
            Offset = new Location() { X = x, Y = y, Z = z };
        }

        public Location Offset { get; set; }
        public override string ToString()
        {
            return Offset.ToString();
        }
    }
}

