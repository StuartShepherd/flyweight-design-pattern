namespace FlyweightDesignPattern;

public class FlyweightFactory
{
    private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

    public FlyweightFactory(params Car[] args)
    {
        foreach (var car in args)
        {
            AddCar(car);
        }
    }

    public Flyweight GetFlyweight(Car sharedState)
    {
        var key = GetKey(sharedState);

        if (flyweights.ContainsKey(key))
        {
            Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            return flyweights[key];
        }

        Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
        AddCar(sharedState);

        return flyweights[key];
    }

    public void ListFlyweights()
    {
        var count = flyweights.Count;

        Console.WriteLine();
        Console.WriteLine($"FlyweightFactory: I have {count} flyweights:");

        foreach (var flyweight in flyweights)
        {
            Console.WriteLine(flyweight.Key);
        }
    }

    private void AddCar(Car car)
    {
        flyweights.Add(
            GetKey(car),
            new Flyweight(car));
    }

    private string GetKey(Car key)
    {
        List<string> elements = new List<string>();

        elements.Add(key.Model);
        elements.Add(key.Color);
        elements.Add(key.Company);

        if (!String.IsNullOrEmpty(key.Owner))
            elements.Add(key.Owner);

        if (!String.IsNullOrEmpty(key.Number))
            elements.Add(key.Number);

        elements.Sort();

        return string.Join("_", elements);
    }
}
