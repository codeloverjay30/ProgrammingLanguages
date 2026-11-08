```csharp
[Atomicable]
public static class Program{
    [Atomic]
    public static void Main(string[] args)
    { 
        atomic {
        /// =============== ///
        /// all statements in this block are atomic.
        /// thus, values of variables, members, fields etc in this block are **NEVER** changed by other threads. 
        /// =============== ///
        
        // suppose variables or instances have been defined.
        uppercaseText1 = text.ToUpper();
        uppercaseText2 = text.ToUpper();
        uppercaseText1.Should().Be(uppercaseText2); // Pass
        }
    }
}
```