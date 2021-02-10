namespace MarkJPriceCSharp9DotNet5.Ch05
{
    public record ImmutablePerson
    {
        public string FirstName { get; init; }
    public string LastName { get; init; }
}

public record ImmutableVehicle
{
        public int Wheels { get; init; }
public string Color { get; init; }
public string Brand { get; init; }
    }

    public record ImmutableAnimal
{
        string _name;
        string _species;


        public ImmutableAnimal(string name, string species)
{
    _name = name;
    _species = species;
}

public void Deconstruct(out string name, out string species)
{
    name = _name;
    species = _species;
}
    }
}