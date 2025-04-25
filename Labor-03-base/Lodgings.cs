using Labor_03_base.Interfaces;

namespace Labor_03_base;

public class Lodgings : Flat, IRent
{
    // fields
    private int _bookedMonths;

    // constructors
    public Lodgings(double area, int roomsCount, double unitPrice)
        : base(area, roomsCount, 0, unitPrice)
    {
        _bookedMonths = 0;
    }

    // methods
    public override bool MoveIn(int newInhabitants)
    {
        if (!IsBooked())
            return false;

        int newInhabCount = InhabitantsCount + newInhabitants;

        // egy szobában max 8
        if (newInhabCount > RoomsCount * 8)
            return false;

        // egy főnek kell 2 m^2
        if (newInhabCount * 2 > Area)
            return false;

        // lakók számának növelése
        InhabitantsCount = newInhabCount;

        return true;
    }

    public int GetCost()
    {
        double price = UnitPrice / 240 / InhabitantsCount;

        return (int)Math.Round(price);
    }

    public bool IsBooked() => _bookedMonths > 0;

    public bool Book(int months)
    {
        if (IsBooked())
            return false;

        _bookedMonths = months;
        return true;
    }

    public override string ToString() => $"{base.ToString()}, bookedMonths: {_bookedMonths}";

    // properties
    public int BookedMonths => _bookedMonths;
}
