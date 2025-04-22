namespace Labor_02_base;

public abstract class Shape
{
    // fields
    private bool _isHoley;
    private string _color;

    // constructors
    protected Shape(string color, bool isHoley = false)
    {
        _color = color;
        _isHoley = isHoley;
    }

    // another way to do it
    // protected Shape(string color, bool isHoley)
    // {
    //     _color = color;
    //     _isHoley = isHoley;
    // }
    //
    // protected Shape(string color)
    //     : this(color, false) { }


    // methods
    public void MakeHoley() => _isHoley = false;

    public abstract double Perimeter();
    public abstract double Area();

    public override string ToString() =>
        $"Color: {_color}, Is Holey: {(_isHoley ? "yes" : "no")}, Perimeter: {Perimeter()}, Area: {Area()}";

    // properties
    public bool IsHoley
    {
        get => _isHoley;
        protected set => _isHoley = value;
    }

    public string Color
    {
        get => _color;
        protected set => _color = value;
    }
}
