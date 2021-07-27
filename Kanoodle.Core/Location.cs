namespace Kanoodle.Core
{
    public struct Location
    {
        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public override string ToString()
        {
            return $"{{{X}, {Y}, {Z}}}";
        }
    }
}

