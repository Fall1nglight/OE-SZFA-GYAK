using Labor_02_base;

namespace Labor_02_test;

public class CircleTests
{
    // fields
    private Circle _circle;

    [SetUp]
    public void Setup()
    {
        _circle = new Circle(100, "red");
    }

    [TestCase(10.5, "red")]
    [TestCase(3.75, "green", true)]
    public void ConstructorTest(double radius, string color, bool isHoley = false)
    {
        _circle = new Circle(radius, color, isHoley);

        Assert.That(_circle.Radius, Is.EqualTo(radius));
        Assert.That(_circle.Color, Is.EqualTo(color));
        Assert.That(_circle.IsHoley, Is.EqualTo(isHoley));
    }

    [TestCase(0, "red")]
    [TestCase(-1, "green", true)]
    public void ConstructorThrowTest(double radius, string color, bool isHoley = false)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _circle = new Circle(radius, color, isHoley);
        });
    }

    [TestCase(100)]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(25)]
    public void PerimeterTest(double radius)
    {
        _circle.Radius = radius;
        double expected = 2 * radius * Math.PI;

        Assert.That(_circle.Perimeter(), Is.EqualTo(expected));
    }

    [TestCase(100)]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(25)]
    public void AreaTest(double radius)
    {
        _circle.Radius = radius;
        double expected = Math.Pow(radius, 2) * Math.PI;

        Assert.That(_circle.Area(), Is.EqualTo(expected));
    }

    [TestCase(10, "green")]
    [TestCase(100, "red")]
    [TestCase(125, "blue", true)]
    [TestCase(140, "yellow", true)]
    public void ToStringTest(double radius, string color, bool isHoley = false)
    {
        _circle = new Circle(radius, color, isHoley);

        double perimeter = 2 * radius * Math.PI;
        double area = Math.Pow(radius, 2) * Math.PI;

        string expected =
            $"Color: {color}, Is Holey: {(isHoley ? "yes" : "no")}, Perimeter: {perimeter}, Area: {area}, Circle.";

        Assert.That(_circle.ToString(), Is.EqualTo(expected));
    }

    [TestCase(10, "green")]
    [TestCase(100, "blue", true)]
    public void EqualsTest(double radius, string color, bool isHoley = false)
    {
        _circle = new Circle(radius, color, isHoley);
        Circle circleNew = new Circle(radius, color, isHoley);

        Assert.That(_circle.Equals(circleNew), Is.EqualTo(true));

        _circle.Radius++;

        Assert.That(_circle.Equals(circleNew), Is.EqualTo(false));
    }
}
