using Labor_03_base.Interfaces;

namespace Labor_03_base;

public class Garage : IRealEstate, IRent
{
    // fields
    private double _area;
    private double _unitPrice;
    private bool _isHeated;
    private int _months;
    private bool _isOccupied;

    // constructors
    public Garage(
        double area,
        double unitPrice,
        bool isHeated,
        int months = 0,
        bool isOccupied = false
    )
    {
        _area = area;
        _unitPrice = unitPrice;
        _isHeated = isHeated;
        _months = months;
        _isOccupied = isOccupied;
    }

    // methods
    public int TotalValue() => (int)Math.Round(_area * _unitPrice);

    public int GetCost()
    {
        double price = _unitPrice / 120 * (_isHeated ? 1.5 : 1);

        return (int)Math.Round(price);
    }

    public bool IsBooked() => _months > 0;

    public bool Book(int months)
    {
        if (IsBooked())
            return false;

        _months = months;
        return true;
    }

    public void UpdateOccupied() => _isOccupied = !_isOccupied;

    public override string ToString() =>
        $"Area: {_area}, unitPrice: {_unitPrice}, isHeated: {_isHeated}, bookedMonths: {_months}, isOccupied: {_isHeated}";

    // properties
}
