using System.Globalization;
using Labor_03_base.Interfaces;

namespace Labor_03_base;

public class AparptmentHouse
{
    // fields
    public IRealEstate[] RealEstates { get; private set; }
    private int _flatCount;
    private int _garageCount;
    private int _maxFlat;
    private int _maxGarage;

    // constructors
    public AparptmentHouse(int maxFlat, int maxGarage)
    {
        RealEstates = new IRealEstate[maxFlat + maxGarage];
        _flatCount = 0;
        _garageCount = 0;
        _maxFlat = maxFlat;
        _maxGarage = maxGarage;
    }

    // methods
    public bool AddProp(IRealEstate prop)
    {
        if (GetIndex() == RealEstates.Length)
            return false;

        if (prop is Flat)
        {
            if (_flatCount == _maxFlat)
                return false;

            _flatCount++;
        }

        if (prop is Garage)
        {
            if (_garageCount == _maxGarage)
                return false;

            _garageCount++;
        }

        RealEstates[GetIndex()] = prop;
        return true;
    }

    public int TotalValue()
    {
        int sum = 0;

        for (int i = 0; i < GetIndex(); i++)
        {
            IRealEstate tmpProp = RealEstates[i];

            if (!IsPropOccupied(tmpProp))
                continue;

            sum += tmpProp.TotalValue();
        }

        return sum;
    }

    private bool IsPropOccupied(IRealEstate prop)
    {
        if (prop is Flat { InhabitantsCount: >= 1 })
            return true;

        return prop is Garage garage && garage.IsBooked();
    }

    private int GetInhabCount()
    {
        int sum = 0;

        for (int i = 0; i < GetIndex(); i++)
        {
            if (RealEstates[i] is not Flat flat)
                continue;

            sum += flat.InhabitantsCount;
        }

        return sum;
    }

    public static AparptmentHouse LoadFromFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Failed to open file.");

        string[] lines = File.ReadAllLines(path);

        int garageCount = lines.Count(line => line.StartsWith("Garage", StringComparison.Ordinal));
        int flatCount = lines.Length - garageCount;

        AparptmentHouse house = new AparptmentHouse(flatCount, garageCount);

        foreach (string line in lines)
            house.AddProp(ParseProperty(line));

        return house;
    }

    private static IRealEstate ParseProperty(string line)
    {
        string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string type = parts[0];
        double area = double.Parse(parts[1], CultureInfo.InvariantCulture);

        return type switch
        {
            "Lodgings" => new Lodgings(
                area,
                int.Parse(parts[2]),
                double.Parse(parts[3], CultureInfo.InvariantCulture)
            ),

            "FamilyApartment" => new FamilyApartment(
                area,
                int.Parse(parts[2]),
                double.Parse(parts[3], CultureInfo.InvariantCulture)
            ),

            "Garage" => new Garage(
                area,
                double.Parse(parts[2], CultureInfo.InvariantCulture),
                bool.Parse(parts[3])
            ),

            _ => throw new InvalidOperationException($"Unknown type: {type}"),
        };
    }

    // properties
    private int GetIndex() => _flatCount + _garageCount;

    public int InhabitantsCount => GetInhabCount();
}
