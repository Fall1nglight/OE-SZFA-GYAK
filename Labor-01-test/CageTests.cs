using Labor_01_base;
using Labor_01_base.Enums;

namespace Labor_01_test;

public class CageTests
{
    private Animal _dog;
    private Animal _panda;
    private Animal _rabbit;

    [SetUp]
    public void Setup()
    {
        _dog = new Animal("Dorka", false, 30, Species.Dog);
        _panda = new Animal("Dorka", true, 55, Species.Panda);
        _rabbit = new Animal("Mici", false, 2, Species.Rabbit);
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(10, 10)]
    [TestCase(15, 10)]
    public void ConstructorPosTest(int size, int expected)
    {
        Cage cage = new Cage(size);
        Assert.That(cage.Animals.Length, Is.EqualTo(expected));
    }

    [TestCase(-1)]
    [TestCase(-15)]
    public void ConstructorNegTest(int size)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Cage cage = new Cage(size);
        });
    }

    [TestCase(3, 1, true)]
    [TestCase(3, 3, true)]
    [TestCase(4, 3, true)]
    [TestCase(2, 3, false)]
    [TestCase(15, 300, false)]
    public void AddTest(int size, int addCount, bool expected)
    {
        Cage cage = new Cage(size);

        for (int i = 0; i < addCount - 1; i++)
            cage.Add(_dog);

        Assert.That(cage.Add(_dog), Is.EqualTo(expected));
    }

    [TestCase(DeleteMethods.Delete1)]
    [TestCase(DeleteMethods.Delete2)]
    [TestCase(DeleteMethods.Delete3)]
    public void DeleteTest(DeleteMethods dm)
    {
        Cage cage = new Cage(10);

        cage.Add(_dog);
        cage.Add(_panda);
        cage.Add(_rabbit);

        Animal[] expected = new Animal[10];
        expected[0] = _rabbit;

        cage.Delete("Dorka", dm);
        Assert.That(cage.Animals, Is.EqualTo(expected));
    }

    [TestCase(Species.Dog, 1)]
    [TestCase(Species.Panda, 2)]
    [TestCase(Species.Rabbit, 3)]
    public void CountSpeciesTest(Species species, int expected)
    {
        Cage cage = new Cage(6);

        cage.Add(_dog);
        cage.Add(_panda);
        cage.Add(_panda);
        cage.Add(_rabbit);
        cage.Add(_rabbit);
        cage.Add(_rabbit);

        Assert.That(cage.CountSpecies(species), Is.EqualTo(expected));
    }

    [TestCase(Species.Dog, false, true)]
    [TestCase(Species.Dog, true, false)]
    [TestCase(Species.Panda, true, true)]
    [TestCase(Species.Panda, false, false)]
    [TestCase(Species.Rabbit, false, true)]
    [TestCase(Species.Rabbit, true, false)]
    public void ContainsTest(Species species, bool gender, bool expected)
    {
        Cage cage = new Cage(3);

        cage.Add(_dog);
        cage.Add(_panda);
        cage.Add(_rabbit);

        Assert.That(cage.Contains(species, gender), Is.EqualTo(expected));
    }

    [TestCase(Species.Dog, 1)]
    [TestCase(Species.Panda, 2)]
    [TestCase(Species.Rabbit, 3)]
    public void SelectTest(Species species, int count)
    {
        Cage cage = new Cage(6);

        cage.Add(_dog);
        cage.Add(_panda);
        cage.Add(_panda);
        cage.Add(_rabbit);
        cage.Add(_rabbit);
        cage.Add(_rabbit);

        Assert.That(cage.Select(species).Length, Is.EqualTo(count));
    }

    [TestCase(Species.Dog, 25)]
    [TestCase(Species.Panda, 32.5)]
    [TestCase(Species.Rabbit, 6)]
    public void AvgWeightTest(Species species, double expected)
    {
        Cage cage = new Cage(6);
        Animal dog2 = new Animal("Folti", false, 20, Species.Dog);
        Animal panda2 = new Animal("Lajos", true, 10, Species.Panda);
        Animal rabbit2 = new Animal("Karoly", true, 10, Species.Rabbit);

        cage.Add(_dog);
        cage.Add(_panda);
        cage.Add(_rabbit);
        cage.Add(dog2);
        cage.Add(panda2);
        cage.Add(rabbit2);

        Assert.That(cage.AvgWeight(species), Is.EqualTo(expected));
    }

    [Test]
    public void ContainsOppositeGenderPairTest()
    {
        Cage cage = new Cage(10);
        Animal dog2 = new Animal("Folti", true, 20, Species.Dog);

        cage.Add(_dog);
        cage.Add(_panda);
        cage.Add(_rabbit);

        Assert.That(cage.ContainsOppositeGenderPair(), Is.EqualTo(false));

        cage.Add(dog2);

        Assert.That(cage.ContainsOppositeGenderPair(), Is.EqualTo(true));
    }

    [Test]
    public void MaxSpeciesTest()
    {
        Cage[] cages = new Cage[4];

        #region Cage 1

        cages[0] = new Cage(8);
        cages[0].Add(new Animal("Dorka", false, 10, Species.Dog));
        cages[0].Add(new Animal("Dorka", false, 10, Species.Dog)); // ugyanaz a név
        cages[0].Add(new Animal("Panda1", true, 100, Species.Panda));
        cages[0].Add(new Animal("Panda2", false, 95, Species.Panda));
        cages[0].Add(new Animal("Rabbit1", true, 3, Species.Rabbit));
        cages[0].Add(new Animal("Rabbit2", false, 4, Species.Rabbit));
        cages[0].Add(new Animal("Mixi", true, 7, Species.Dog));
        cages[0].Add(new Animal("Luna", false, 5, Species.Rabbit));
        #endregion

        #region Cage 2

        cages[1] = new Cage(9);
        cages[1].Add(new Animal("Luna", false, 12, Species.Dog));
        cages[1].Add(new Animal("Luna", false, 12, Species.Dog)); // ismétlődő név
        cages[1].Add(new Animal("Bamboo", true, 110, Species.Panda));
        cages[1].Add(new Animal("Pandy", false, 102, Species.Panda));
        cages[1].Add(new Animal("Fluffy", true, 3, Species.Rabbit));
        cages[1].Add(new Animal("Snow", false, 4, Species.Rabbit));
        cages[1].Add(new Animal("Charlie", true, 11, Species.Dog));
        cages[1].Add(new Animal("Thumper", false, 5, Species.Rabbit));
        #endregion

        #region Cage 3

        cages[2] = new Cage(6);
        cages[2].Add(new Animal("Rex", true, 14, Species.Dog));
        cages[2].Add(new Animal("Rex", true, 14, Species.Dog)); // ismétlődő név
        cages[2].Add(new Animal("Bao", true, 120, Species.Panda));
        cages[2].Add(new Animal("Mei", false, 100, Species.Panda));
        cages[2].Add(new Animal("Cotton", true, 2, Species.Rabbit));
        cages[2].Add(new Animal("Cotton", false, 3, Species.Rabbit)); // ismétlődő név
        #endregion

        #region Cage 4

        cages[3] = new Cage(10);
        cages[3].Add(new Animal("Max", true, 9, Species.Dog));
        cages[3].Add(new Animal("Max", true, 9, Species.Dog)); // ismétlődő név
        cages[3].Add(new Animal("Pandy", true, 97, Species.Panda));
        cages[3].Add(new Animal("Bao", false, 93, Species.Panda));
        cages[3].Add(new Animal("Bunny", true, 3, Species.Rabbit));
        cages[3].Add(new Animal("Bunny", false, 3, Species.Rabbit)); // ismétlődő név
        cages[3].Add(new Animal("Lola", false, 4, Species.Rabbit));
        cages[3].Add(new Animal("Buddy", true, 8, Species.Dog));
        cages[3].Add(new Animal("Toby", false, 10, Species.Dog));
        cages[3].Add(new Animal("Zoe", false, 2, Species.Rabbit));
        #endregion

        Assert.That(Cage.MaxSpecies(cages, Species.Dog), Is.EqualTo(3));
    }
}
