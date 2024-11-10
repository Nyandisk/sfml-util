public struct Vector2(double x = 0, double y = 0)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public readonly double Magnitude { get { return Math.Sqrt(X * X + Y * Y); } }
    public readonly double MagnitudeSquared => X * X + Y * Y;
    public readonly Vector2 Normalized { get { return new(X / Magnitude, Y / Magnitude); } }
    public readonly Vector2 PerpendicularCW => new(Y, -X);
    public readonly Vector2 PerpendicularACW => new(-Y, X);
    public readonly Vector2 Reverse => -this;
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new(a.X + b.X, a.Y + b.Y);
    }
    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new(a.X - b.X, a.Y - b.Y);
    }
    public static Vector2 operator -(Vector2 a)
    {
        return new(-a.X, -a.Y);
    }
    public static Vector2 operator *(Vector2 v, double scalar)
    {
        return new Vector2(v.X * scalar, v.Y * scalar);
    }
    public static Vector2 operator *(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
    }
    public static Vector2 operator /(Vector2 v, double scalar)
    {
        return new Vector2(v.X / scalar, v.Y / scalar);
    }
    public static Vector2 operator /(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
    }
    public static Vector2 operator *(double scalar, Vector2 v)
    {
        return new Vector2(v.X * scalar, v.Y * scalar);
    }
    public static Vector2 operator /(double scalar, Vector2 v)
    {
        return new Vector2(v.X / scalar, v.Y / scalar);
    }
    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }
    public static double Cross(Vector2 a, Vector2 b)
    {
        return a.X * b.Y - a.Y * b.X;
    }
    public static double Dot(Vector2 a, Vector2 b)
    {
        return a.X * b.X + a.Y * b.Y;
    }
    public static double AngleBetween(Vector2 a, Vector2 b)
    {
        double dot = Dot(a, b);
        double magnitudes = a.Magnitude * b.Magnitude;
        if (magnitudes == 0) return 0;

        double theta = dot / magnitudes;
        theta = Math.Clamp(theta, -1.0, 1.0);
        return Math.Acos(theta);
    }
    public static Vector2 Projection(Vector2 a, Vector2 b)
    {
        double scalar = Dot(a, b) / (b.X * b.X + b.Y * b.Y);
        return new Vector2(b.X * scalar, b.Y * scalar);
    }
    public static Vector2 Lerp(Vector2 a, Vector2 b, double t)
    {
        t = Math.Clamp(t, 0.0, 1.0);
        return a + (b - a) * t;
    }

    public static double Distance(Vector2 a, Vector2 b)
    {
        return (a - b).Magnitude;
    }
    public static double SquaredDistance(Vector2 a, Vector2 b)
    {
        return (a - b).MagnitudeSquared;
    }
    public static Vector2 Reflect(Vector2 v, Vector2 n)
    {
        return v - 2 * Dot(v, n) * n;
    }
    public static implicit operator Vector2f(Vector2 v)
    {
        return new((float)v.X, (float)v.Y);
    }
    public static implicit operator Vector2i(Vector2 v)
    {
        return new((int)v.X, (int)v.Y);
    }
    public static implicit operator Vector2u(Vector2 v)
    {
        return new((uint)v.X, (uint)v.Y);
    }

    public static implicit operator Vector2(Vector2f v)
    {
        return new(v.X, v.Y);
    }
    public static implicit operator Vector2(Vector2i v)
    {
        return new(v.X, v.Y);
    }
    public static implicit operator Vector2(Vector2u v)
    {
        return new(v.X, v.Y);
    }

    public override readonly bool Equals(object? obj)
    {
        if (obj is Vector2 v)
        {
            return this == v;
        }
        return false;
    }
    public override readonly int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
    public override readonly string ToString()
    {
        return $"{X};{Y}";
    }
}
