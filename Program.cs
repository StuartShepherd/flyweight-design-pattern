
using FlyweightDesignPattern;

Console.WriteLine("Flyweight Design Pattern");
Console.WriteLine("Flyweight is a structural design pattern that allows programs to support vast quantities of objects by keeping their memory consumption low.");
Console.WriteLine();

var factory = new FlyweightFactory(
    new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
    new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
    new Car { Company = "BMW", Model = "M5", Color = "red" },
    new Car { Company = "BMW", Model = "X6", Color = "white" }
);
factory.ListFlyweights();

AddCarToPoliceDatabase(factory, new Car
{
    Number = "Alpha123",
    Owner = "Stuart Shepherd",
    Company = "BMW",
    Model = "M5",
    Color = "red"
});

AddCarToPoliceDatabase(factory, new Car
{
    Number = "Beta123",
    Owner = "Stuart Shepherd",
    Company = "BMW",
    Model = "X1",
    Color = "red"
});

factory.ListFlyweights();

static void AddCarToPoliceDatabase(FlyweightFactory factory, Car car)
{
    Console.WriteLine();
    Console.WriteLine("Client: Adding a car to database.");
    Console.WriteLine();

    var flyweight = factory.GetFlyweight(new Car
    {
        Color = car.Color,
        Model = car.Model,
        Company = car.Company
    });

    flyweight.Operation(car);
}
