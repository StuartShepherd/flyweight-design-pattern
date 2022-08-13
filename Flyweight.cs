namespace FlyweightDesignPattern;

using System.Text.Json;

public class Flyweight
{
    private readonly Car _sharedState;

    public Flyweight(Car car)
    {
        _sharedState = car;
    }

    public void Operation(Car uniqueState)
    {
        var serializedSharedState = JsonSerializer.Serialize(_sharedState);
        var searlizedUniqueState = JsonSerializer.Serialize(uniqueState);

        Console.WriteLine($"Flyweight: Displaying shared {serializedSharedState} and unique {searlizedUniqueState} state.");
    }
}
