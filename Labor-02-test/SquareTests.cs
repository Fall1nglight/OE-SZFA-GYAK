using Labor_02_base;

namespace Labor_02_test;

public class SquareTests
{
    // fields
    private Square _square;

    [SetUp]
    public void Setup()
    {
        _square = new Square(100, "red");
    }

    [TestCase(100, "red")]
    [TestCase(250, "red")]
    [TestCase(100, "red", true)]
    [TestCase(250, "red", true)]
    public void ConstructorTest(int height, string color, bool isHoley = false)
    {
        _square = new Square(height, color, isHoley);

        Assert.That(_square.Width, Is.EqualTo(_square.Height));
    }

    [TestCase(100)]
    [TestCase(250)]
    public void HeightTest(int height)
    {
        _square.Height = height;

        Assert.That(_square.Width, Is.EqualTo(height));
    }

    [TestCase(100)]
    [TestCase(250)]
    public void WidthTest(int width)
    {
        _square.Width = width;

        Assert.That(_square.Height, Is.EqualTo(width));
    }

    [TestCase(100, "red")]
    [TestCase(250, "red")]
    [TestCase(100, "red", true)]
    [TestCase(250, "red", true)]
    public void ToStringTest(int height, string color, bool isHoley = false)
    {
        _square = new Square(height, color, isHoley);
        string expected =
            $"Square. Color: {color}, Is Holey: {(isHoley ? "yes" : "no")}, Perimeter: {height * 4}, Area: {Math.Pow(height, 2)}, Rectangle.";

        Assert.That(_square.ToString(), Is.EqualTo(expected));
    }

    [TestCase(10, 15, "green")]
    [TestCase(100, 150, "blue", true)]
    public void EqualsTest(int height, int width, string color, bool isHoley = false)
    {
        _square = new Square(height, color, isHoley);
        Square squareNew = new Square(height, color, isHoley);

        Assert.That(_square.Equals(squareNew), Is.EqualTo(true));

        _square.Width++;

        Assert.That(_square.Equals(squareNew), Is.EqualTo(false));
    }
}
