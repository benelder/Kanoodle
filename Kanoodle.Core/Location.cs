namespace Kanoodle.Core
{
    public struct Location
    {
        public Location(int a, int b, int g)
        {
            A = a;
            B = b;
            G = g;
        }
        public int A { get; set; }
        public int B { get; set; }
        public int G { get; set; }
        public override string ToString()
        {
            return $"{{{A}, {B}, {G}}}";
        }
    }
}

