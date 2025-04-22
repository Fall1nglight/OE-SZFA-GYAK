using Labor_02_base;

namespace Labor_02_test;

public class RectangleTests
{
    // fields
    private Rectangle _rectangle;

    [SetUp]
    public void Setup()
    {
        _rectangle = new Rectangle(100, 100, "red");
    }

    [TestCase(10, 15, "green")]
    [TestCase(100, 15, "red")]
    [TestCase(100, 150, "blue", true)]
    [TestCase(1, 1, "yellow", true)]
    public void ConstructorTest(int height, int width, string color, bool isHoley = false)
    {
        _rectangle = new Rectangle(height, width, color, isHoley);

        Assert.That(_rectangle.Height, Is.EqualTo(height));
        Assert.That(_rectangle.Width, Is.EqualTo(width));
        Assert.That(_rectangle.Color, Is.EqualTo(color));
        Assert.That(_rectangle.IsHoley, Is.EqualTo(isHoley));
    }

    [TestCase(0, 0)]
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(-1, -1)]
    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    public void ConstructorThrowTest(int height, int width)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _rectangle = new Rectangle(height, width, "black");
        });
    }

    [TestCase(100, 100, 400)]
    [TestCase(1, 1, 4)]
    [TestCase(10, 15, 50)]
    [TestCase(25, 25, 100)]
    public void PerimeterTest(int height, int width, int expected)
    {
        _rectangle.Height = height;
        _rectangle.Width = width;

        Assert.That(_rectangle.Perimeter(), Is.EqualTo(expected));
    }

    [TestCase(100, 100, 10000)]
    [TestCase(1, 1, 1)]
    [TestCase(10, 15, 150)]
    [TestCase(25, 25, 625)]
    public void AreaTest(int height, int width, int expected)
    {
        _rectangle.Height = height;
        _rectangle.Width = width;

        Assert.That(_rectangle.Area(), Is.EqualTo(expected));
    }

    [TestCase(10, 15, "green")]
    [TestCase(100, 15, "red")]
    [TestCase(100, 150, "blue", true)]
    [TestCase(1, 1, "yellow", true)]
    public void ToStringTest(int height, int width, string color, bool isHoley = false)
    {
        _rectangle = new Rectangle(height, width, color, isHoley);
        string expected =
            $"Color: {color}, Is Holey: {(isHoley ? "yes" : "no")}, Perimeter: {(height + width) * 2}, Area: {height * width}, Rectangle.";

        Assert.That(_rectangle.ToString(), Is.EqualTo(expected));
    }

    [TestCase(10, 15, "green")]
    [TestCase(100, 150, "blue", true)]
    public void EqualsTest(int height, int width, string color, bool isHoley = false)
    {
        _rectangle = new Rectangle(height, width, color, isHoley);
        Rectangle rectangleNew = new Rectangle(height, width, color, isHoley);

        Assert.That(_rectangle.Equals(rectangleNew), Is.EqualTo(true));

        _rectangle.Width++;

        Assert.That(_rectangle.Equals(rectangleNew), Is.EqualTo(false));
    }
}
