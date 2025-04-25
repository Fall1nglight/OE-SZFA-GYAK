using Labor_03_base.Interfaces;

namespace Labor_03_base;

public abstract class Flat : IRealEstate
{
    // fields
    private double _area;
    private int _roomsCount;
    private int _inhabitantsCount;
    private double _unitPrice;

    // constructors
    public Flat(double area, int roomsCount, int inhabitantsCount, double unitPrice)
    {
        _area = area;
        _roomsCount = roomsCount;
        _inhabitantsCount = inhabitantsCount;
        _unitPrice = unitPrice;
    }

    // methods
    public abstract bool MoveIn(int newInhabitants);

    public int TotalValue() => (int)Math.Round(_area * _unitPrice);

    public override string ToString() =>
        $"Area: {_area}, roomsCount: {_roomsCount}, inhabitantsCount: {_inhabitantsCount}, unitPrice: {_unitPrice}";

    // properties
    public double Area
    {
        get => _area;
        protected set => _area = value;
    }

    public int RoomsCount
    {
        get => _roomsCount;
        protected set => _roomsCount = value;
    }

    public int InhabitantsCount
    {
        get => _inhabitantsCount;
        protected set => _inhabitantsCount = value;
    }

    public double UnitPrice
    {
        get => _unitPrice;
        protected set => _unitPrice = value;
    }
}
