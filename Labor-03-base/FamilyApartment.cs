namespace Labor_03_base;

public class FamilyApartment : Flat
{
    // fields
    private int _childrenCount;

    // constructors
    public FamilyApartment(double area, int roomsCount, double unitPrice)
        : base(area, roomsCount, 0, unitPrice)
    {
        _childrenCount = 0;
    }

    // methods
    public override bool MoveIn(int newInhabitants)
    {
        double newInhabCount = AdultCount() + newInhabitants + _childrenCount * 0.5;

        if (newInhabCount * 10 > Area)
            return false;

        if (newInhabCount > RoomsCount * 2)
            return false;

        InhabitantsCount += newInhabitants;
        return true;
    }

    public bool ChildIsBorn()
    {
        if (AdultCount() < 2)
            return false;

        InhabitantsCount++;
        _childrenCount++;

        return true;
    }

    public override string ToString() => $"{base.ToString()}, childrenCount: {_childrenCount}";

    private int AdultCount() => InhabitantsCount - _childrenCount;

    // properties
    public int ChildrenCount => _childrenCount;
}
