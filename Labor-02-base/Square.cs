namespace Labor_02_base;

public class Square : Rectangle
{
    // fields

    // constructors
    public Square(int height, string color, bool isHoley = false)
        : base(height, height, color, isHoley) { }

    // methods
    public override string ToString() => $"Square. {base.ToString()}";

    public override bool Equals(object? obj)
    {
        if (obj is not Square temp)
            return false;

        return Height == temp.Height
            && Color.Equals(temp.Color, StringComparison.Ordinal)
            && IsHoley == temp.IsHoley;
    }

    // properties
    public override int Height
    {
        get => base.Height;
        set => base.Height = base.Width = value;
    }

    public override int Width
    {
        get => base.Width;
        set => base.Height = base.Width = value;
    }
}
