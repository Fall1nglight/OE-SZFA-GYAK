// ReSharper disable VirtualMemberCallInConstructor
namespace Labor_02_base;

public class Rectangle : Shape
{
    // fields
    private int _height;
    private int _width;

    // constructors
    public Rectangle(int height, int width, string color, bool isHoley = false)
        : base(color, isHoley)
    {
        Height = height;
        Width = width;
    }

    // methods
    public override double Perimeter() => (_height + _width) * 2;

    public override double Area() => _height * _width;

    public override string ToString() => $"{base.ToString()}, Rectangle.";

    public override bool Equals(object? obj)
    {
        if (obj is not Rectangle temp)
            return false;

        return _height == temp.Height
            && _width == temp.Width
            && Color.Equals(temp.Color, StringComparison.Ordinal)
            && IsHoley == temp.IsHoley;
    }

    // properties
    public virtual int Height
    {
        get => _height;
        set =>
            _height =
                value > 0
                    ? value
                    : throw new ArgumentException(
                        nameof(value),
                        $"{nameof(value)} cannot be zero or negative number"
                    );
    }

    public virtual int Width
    {
        get => _width;
        set =>
            _width =
                value > 0
                    ? value
                    : throw new ArgumentException(
                        nameof(value),
                        $"{nameof(value)} cannot be zero or negative number"
                    );
    }
}
