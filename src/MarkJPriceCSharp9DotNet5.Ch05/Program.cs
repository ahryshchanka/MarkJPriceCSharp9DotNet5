using MarkJPriceCSharp9DotNet5.Ch05;
using static System.Console;

WriteLine("Hello World!");

var car = new ImmutableVehicle
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};
var repaintedCar = car with { Color = "Polymetal Grey Metallic" };

WriteLine("Original color was {0}, new color is {1}.", arg0: car.Color, arg1: car.Color);
WriteLine("Original color was {0}, new color is {1}.", arg0: repaintedCar.Color, arg1: repaintedCar.Color);

WriteLine($"{nameof(car)}, {car}");
WriteLine($"{nameof(repaintedCar)}, {repaintedCar}");

ImmutableAnimal animal = new("name", "species");
var (name, species) = animal;

object[] passengers = {
    new FirstClassPassenger { AirMiles = 1_419 },
    new FirstClassPassenger { AirMiles = 16_562 },
    new BusinessClassPassenger(),
    new CoachClassPassenger { CarryOnKG = 25.7 },
    new CoachClassPassenger { CarryOnKG = 0 },
};

foreach (object passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger _ => 2000M,
        BusinessClassPassenger _ => 1000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

foreach (object passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _ => 2000M
        },
        BusinessClassPassenger => 1000M,
        CoachClassPassenger { CarryOnKG: < 10.0 } => 500M,
        CoachClassPassenger => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

public class BusinessClassPassenger
{
    public override string ToString()
    {
        return $"Business Class";
    }
}
public class FirstClassPassenger
{
    public int AirMiles { get; set; }
    public override string ToString()
    {
        return $"First Class with {AirMiles:N0} air miles";
    }
}
public class CoachClassPassenger
{
    public double CarryOnKG { get; set; }
    public override string ToString()
    {
        return $"Coach Class with {CarryOnKG:N2} KG carry on";
    }
}