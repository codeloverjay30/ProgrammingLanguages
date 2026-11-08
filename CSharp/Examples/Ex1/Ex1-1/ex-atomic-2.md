```csharp
public atomic static void Main(string[] args)
{ 
var anomyousFunction1 = [Atomic] (number){ number = number * number; Console.WriteLine(number); }
anomyousFunction1(2); // always echo 4 (2*2)
}
```