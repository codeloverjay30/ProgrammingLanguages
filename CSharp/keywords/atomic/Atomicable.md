# Atomicable
## info
Idea came up with at:

2026/07/01 12:05 when I wrote [atomic.md](atomic.md)

## usage and effects
It marks the class is atomicable, thus allowing use `atomic` keyword or `[Atomic]` Attribute in data annotations in this class.

If not marked, the compiler will throw a compiler error.

> [!NOTE]
> It can be used for the class.
>

(x) invalid example:

```csharp
// [Atomicable]
public static class Program{
    [Atomicable] // invalid and cause compiler error.
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

## See also
[atomic.md](atomic.md)