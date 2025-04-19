using Labor_01_base.Enums;

namespace Labor_01_base;

public class Cage
{
    // fields
    private Animal[] _animals;
    private int _count;

    // constructors
    public Cage(int size)
    {
        if (size < 0)
            throw new ArgumentException("Size cannot be a negative number.");

        // cage could contain maxmimum 10 animals
        _animals = new Animal[size > 10 ? 10 : size];
        _count = 0;
    }

    // methods
    public bool Add(Animal newAnimal)
    {
        // cage is full
        if (_count == _animals.Length)
            return false;

        _animals[_count++] = newAnimal;

        return true;
    }

    public void Delete(string animalName, DeleteMethods dm)
    {
        switch (dm)
        {
            case DeleteMethods.Delete1:
                Delete1(animalName);
                break;

            case DeleteMethods.Delete2:
                Delete2(animalName);
                break;

            case DeleteMethods.Delete3:
                Delete3(animalName);
                break;
        }
    }

    private void Delete1(string animalName)
    {
        Animal[] result = new Animal[_animals.Length];
        int tempCount = 0;

        for (int i = 0; i < _count; i++)
        {
            if (!string.Equals(_animals[i].Name, animalName, StringComparison.Ordinal))
                result[tempCount++] = _animals[i];
        }

        _animals = result;
    }

    private void Delete2(string animalName)
    {
        for (int i = 0; i < _count; i++)
        {
            if (string.Equals(_animals[i].Name, animalName, StringComparison.Ordinal))
            {
                for (int j = i; j < _count - 1; j++)
                {
                    _animals[j] = _animals[j + 1];
                }

                _animals[--_count] = null!;
                i--;
            }
        }
    }

    private void Delete3(string animalName)
    {
        int newCount = 0;

        for (int i = 0; i < _count; i++)
        {
            if (!string.Equals(_animals[i].Name, animalName, StringComparison.Ordinal))
            {
                _animals[newCount++] = _animals[i];
            }
        }

        for (int i = newCount; i < _count; i++)
        {
            _animals[i] = null!;
        }

        _count = newCount;
    }

    public int CountSpecies(Species species)
    {
        int speciesCount = 0;

        for (int i = 0; i < _count; i++)
        {
            if (_animals[i].Species == species)
                speciesCount++;
        }

        return speciesCount;
    }

    public bool Contains(Species species, bool gender)
    {
        int idx = 0;

        while (
            idx < _count && !(_animals[idx].Species == species && _animals[idx].Gender == gender)
        )
            idx++;

        return idx < _count;
    }

    public Animal[] Select(Species species)
    {
        Animal[] result = new Animal[_count];
        int tempCount = 0;

        for (int i = 0; i < _count; i++)
        {
            if (_animals[i].Species == species)
                result[tempCount++] = _animals[i];
        }

        Array.Resize(ref result, tempCount);

        return result;
    }

    public double AvgWeight(Species species)
    {
        int sum = 0;
        int numOfAnimals = 0;

        for (int i = 0; i < _count; i++)
        {
            if (_animals[i].Species == species)
            {
                sum += _animals[i].Weight;
                numOfAnimals++;
            }
        }

        double result = (double)sum / numOfAnimals;
        return result;
    }

    public bool ContainsOppositeGenderPair()
    {
        foreach (Species species in Enum.GetValues<Species>())
        {
            Animal[] animals = Select(species);

            if (animals.Length <= 1)
                continue;

            bool gender = animals[0].Gender;
            int idx = 1;

            while (idx < animals.Length && animals[idx].Gender == gender)
                idx++;

            if (idx < animals.Length)
                return true;
        }

        return false;
    }

    public static int MaxSpecies(Cage[] cages, Species species)
    {
        int maxIdx = 0;

        for (int i = 1; i < cages.Length; i++)
        {
            if (cages[i].CountSpecies(species) > cages[maxIdx].CountSpecies(species))
                maxIdx = i;
        }

        return maxIdx;
    }

    public void ToConsole()
    {
        Console.WriteLine("Animals in the cage:");

        for (int i = 0; i < _count; i++)
            Console.WriteLine(_animals[i]);
    }

    public static Cage Parse(string path)
    {
        if (!File.Exists(path))
            throw new Exception("File does not exist.");

        string[] arr = File.ReadAllLines(path);

        if (arr.Length > 10)
            throw new Exception("File could contain maximum 10 animals.");

        Cage cage = new Cage(arr.Length);

        foreach (string line in arr)
            cage.Add(Animal.Parse(line));

        return cage;
    }

    public static Cage[] ParseFromDirectory(string path)
    {
        if (!Directory.Exists(path))
            throw new Exception("Invalid directory.");

        string[] files = Directory.GetFiles(path);
        Cage[] cages = new Cage[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            cages[i] = Cage.Parse(files[i]);
        }

        return cages;
    }

    // properties
    public Animal[] Animals => _animals;

    public int Count => _count;
}
