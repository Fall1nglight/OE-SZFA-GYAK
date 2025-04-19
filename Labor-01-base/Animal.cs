using Labor_01_base.Enums;

namespace Labor_01_base;

public class Animal
{
    // fields
    private string _name;
    private bool _gender;
    private int _weight;
    private Species _species;

    // constructors
    public Animal(string name, bool gender, int weight, Species species)
    {
        _name = name;
        _gender = gender;
        _weight = weight;
        _species = species;
    }

    // methods
    public override string ToString() =>
        $"Név: {_name}, nem: {(_gender ? "hím" : "nőstény")}, súly: {_weight} kg, faj: {_species}";

    public static Animal Parse(string line)
    {
        string[] arr = line.Split(",");

        if (arr.Length != 4)
            throw new Exception("Invalid input");

        return new Animal(
            arr[0],
            bool.Parse(arr[1]),
            int.Parse(arr[2]),
            Enum.Parse<Species>(arr[3])
        );
    }

    // properties
    public string Name => _name;

    public bool Gender => _gender;

    public int Weight => _weight;

    public Species Species => _species;
}
