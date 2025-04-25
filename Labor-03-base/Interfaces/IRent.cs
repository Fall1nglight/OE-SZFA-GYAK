namespace Labor_03_base.Interfaces;

public interface IRent
{
    // methods
    int GetCost();
    bool IsBooked();
    bool Book(int months);

    // properties
}
