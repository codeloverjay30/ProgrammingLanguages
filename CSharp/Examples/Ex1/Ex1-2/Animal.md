```csharp
[Atomicable]
public class Animal
{
    private string _name;
    public Animal(string name){
        _name = name;
    }
    public atomic void Say(string message)
    {
        Console.WriteLine($"The animal named {_name} says {message}");
    }
}
```

```csharp
[Atomicable]
public static class Program{
    [Atomic]
    public static void Main(string[] args)
    { 
    var me = new Animal("jay30");
    me.Say("I'm a human"); // always echo "The animal named jay30 says I'm a human"
    }
}
```