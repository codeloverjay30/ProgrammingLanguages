# atomic
## info
Idea came up with at:

2026/06/30 21:45 which I took a shower.

via: the worry about the following issue at 2026/06/30 

+ unsafe variable value issue: (discussed in other chat of gem, available at [shared link](https://share.gemini.google/rMZsXzD8sSZJ))

Will the value of `s` be changed by other thread between initialization and conditional statement at runtime? 

```csharp
string s = instance.property;
if(!string.IsNullOrWhitespace(s)) // <-- Will value of `s` will be changed by other threads
{

}
```

## movitation
always ensure atomicity.

always ensure that values of variables, members, fields etc are **NEVER** changed by other threads. 

## usage and effects
Using `atomic` keyword or `AtomicAttribute` (or shorthand form `Atomic`) Attribute in data annotation 

### In blocks
just use the keyword `atomic`.

See [example 1-1](../../Examples/Ex1/Ex1-1/ex-atomic.md)

### Inside methods
Just use the keyword `atomic` as its modifier or `AtomicAttribute` (or shorthand form `Atomic`) Attribute in data annotation 

It will apply to all statements inside methods and its sequent methods call in these statements.

See [example 1-2](../../Examples/Ex1/Ex1-2/Animal.md)

or equivalently

[example 1-2](../../Examples/Ex1/Ex1-2/Animal.eq.md)

### Inside functions
Similar to [Inside methods](atomic.md#inside-methods)

### Properties
It applies to this property or statements that uses this property in all members of this class (which defines this property)

See [example 1-3](../../Examples/Ex1/Ex1-3/Employee.md)

or equivalently

[example 1-3](../../Examples/Ex1/Ex1-3/Employee.eq.md)

### parameters
It applies to this property or statements that uses this property in this methods (which contains this parameter)

See codes on the [project](../../Examples/Ex1/Ex1-4/Game.Core/Game.Core.csproj)

### Inside classes
Similar to [Inside methods](atomic.md#inside-methods).

But it applies to all members (all properties, all methods etc) in the class.

### In anomyous functions
Just mark it with `Atomic` Attribute before the definition of anomyous function.

See [example 1-1](../../Examples/Ex1/Ex1-1/ex-atomic-2.md)

## See also
[Atomicable.md](Atomicable.md)