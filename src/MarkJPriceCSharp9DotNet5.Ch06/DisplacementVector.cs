// unset

namespace MarkJPriceCSharp9DotNet5.Ch06
{
    public class DisplacementVector
    {
        public int X { get; init; }
        public int Y { get; init; }

        public DisplacementVector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static DisplacementVector operator +(DisplacementVector o1, DisplacementVector o2)
            => new DisplacementVector(o1.X + o2.X, o1.Y + o2.Y);

        public override string ToString() => $"({X}, {Y})";
    }
}