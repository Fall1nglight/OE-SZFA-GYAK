namespace Labor_02_base;

public class Circle : Shape
{
    // fields
    private double _radius;

    // constructors
    public Circle(double radius, string color, bool isHoley = false)
        : base(color, isHoley)
    {
        Radius = radius;
    }

    // methods
    public override double Perimeter() => 2 * _radius * Math.PI;

    public override double Area() => Math.Pow(_radius, 2) * Math.PI;

    public override string ToString() => $"{base.ToString()}, Circle.";

    public override bool Equals(object? obj)
    {
        if (obj is not Circle temp)
            return false;

        return _radius.Equals(temp.Radius)
            && Color.Equals(temp.Color, StringComparison.Ordinal)
            && IsHoley == temp.IsHoley;
    }

    // properties
    public double Radius
    {
        get => _radius;
        set =>
            _radius =
                value > 0
                    ? value
                    : throw new ArgumentException(
                        nameof(value),
                        $"{nameof(value)} cannot be zero or negative number"
                    );
    }
}
