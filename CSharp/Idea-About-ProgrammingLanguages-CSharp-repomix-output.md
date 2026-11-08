This file is a merged representation of the entire codebase, combined into a single document by Repomix.

# File Summary

## Purpose
This file contains a packed representation of the entire repository's contents.
It is designed to be easily consumable by AI systems for analysis, code review,
or other automated processes.

## File Format
The content is organized as follows:
1. This summary section
2. Repository information
3. Directory structure
4. Repository files (if enabled)
5. Multiple file entries, each consisting of:
  a. A header with the file path (## File: path/to/file)
  b. The full contents of the file in a code block

## Usage Guidelines
- This file should be treated as read-only. Any changes should be made to the
  original repository files, not this packed version.
- When processing this file, use the file path to distinguish
  between different files in the repository.
- Be aware that this file may contain sensitive information. Handle it with
  the same level of security as you would the original repository.

## Notes
- Some files may have been excluded based on .gitignore rules and Repomix's configuration
- Binary files are not included in this packed representation. Please refer to the Repository Structure section for a complete list of file paths, including binary files
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Files are sorted by Git change count (files with more changes are at the bottom)

# Directory Structure
```
.repomixignore
Examples/Ex1/Ex1-1/ex-atomic-2.md
Examples/Ex1/Ex1-1/ex-atomic.md
Examples/Ex1/Ex1-2/Animal.eq.md
Examples/Ex1/Ex1-2/Animal.md
Examples/Ex1/Ex1-3/Employee.eq.md
Examples/Ex1/Ex1-3/Employee.md
Examples/Ex1/Ex1-4/Game.Core/BuffBase.cs
Examples/Ex1/Ex1-4/Game.Core/BuffProvider.cs
Examples/Ex1/Ex1-4/Game.Core/BuffType.cs
Examples/Ex1/Ex1-4/Game.Core/DebuffProvider.cs
Examples/Ex1/Ex1-4/Game.Core/Game.Core.csproj
Examples/Ex1/Ex1-4/Game.Core/LiveStatus.cs
Examples/Ex1/Ex1-4/Game.Core/Program.cs
Examples/Ex1/Ex1-4/Game.Core/Role.cs
Examples/Ex1/Ex1-4/Game.Core/RoleAttribute.cs
Examples/Ex1/Ex1-4/Game.Core/RoleAttributes.cs
Examples/Ex1/Ex1-4/Game.Core/RoleAttributeUtilityService.cs
Examples/Ex1/Ex1-4/Game.Core/RoleBasicInfo.cs
Examples/Ex1/Ex1-4/Game.Core/RoleType.cs
keywords/atomic/atomic.md
keywords/atomic/Atomicable.md
keywords/Depends/Depends.md
repomix.config.json
```

# Files

## File: .repomixignore
````
# Add patterns to ignore here, one per line
# Example:
# *.log
# tmp/
````

## File: Examples/Ex1/Ex1-1/ex-atomic-2.md
````markdown
```csharp
public atomic static void Main(string[] args)
{ 
var anomyousFunction1 = [Atomic] (number){ number = number * number; Console.WriteLine(number); }
anomyousFunction1(2); // always echo 4 (2*2)
}
```
````

## File: Examples/Ex1/Ex1-1/ex-atomic.md
````markdown
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
````

## File: Examples/Ex1/Ex1-2/Animal.eq.md
````markdown
```csharp
[Atomicable]
public class Animal
{
    private string _name;
    public Animal(string name){
        _name = name;
    }
    [Atomic]
    public void Say(string message)
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
````

## File: Examples/Ex1/Ex1-2/Animal.md
````markdown
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
````

## File: Examples/Ex1/Ex1-3/Employee.eq.md
````markdown
```csharp
[Atomicable]
public class Employee
{
    private string _name;
    public string Name { get {return _name;} set { value = _name;}}
    [Atomic]
    private int _workingHours;
    public int WorkingHours { get {return _workingHours;} set { value = _workingHours;}}

    public Employee(string name,int workingHours){
        _name = name;
        _workingHours = workingHours; // atomic
    }
    public void Work(int hours){
        _workingHours += hours; // atomic
    }
    public int GetSalary()
    {
        return _workingHours * 200; // atomic
    }
}
```
````

## File: Examples/Ex1/Ex1-3/Employee.md
````markdown
```csharp
[Atomicable]
public class Employee
{
    private string _name;
    public string Name { get {return _name;} set { value = _name;}}
    private atomic int _workingHours;
    public int WorkingHours { get {return _workingHours;} set { value = _workingHours;}}

    public Employee(string name,int workingHours){
        _name = name;
        _workingHours = workingHours; // atomic
    }
    public void Work(int hours){
        _workingHours += hours; // atomic
    }
    public int GetSalary()
    {
        return _workingHours * 200; // atomic
    }
}
```
````

## File: Examples/Ex1/Ex1-4/Game.Core/BuffBase.cs
````csharp
namespace Game.Core;
public record class BuffBase
{
    public required BuffType Type { get; init; }
    [Range(0, 10m)]
    public required decimal BuffEffectMultiplier { get; init; }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/BuffProvider.cs
````csharp
namespace Game.Core;

public class BuffProvider
{
    public static BuffBase Create(int buffEffectMultiplier)
    {
        return new BuffBase
        {
            Type = BuffType.Buff,
            BuffEffectMultiplier = buffEffectMultiplier,
        };
    }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/BuffType.cs
````csharp
public enum BuffType
{
    Buff,
    Debuff,
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/DebuffProvider.cs
````csharp
namespace Game.Core;

public class DebuffProvider
{
    public static BuffBase Create(int buffEffectMultiplier)
    {
        return new BuffBase
        {
            Type = BuffType.Debuff,
            BuffEffectMultiplier = buffEffectMultiplier,
        };
    }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/Game.Core.csproj
````
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
````

## File: Examples/Ex1/Ex1-4/Game.Core/LiveStatus.cs
````csharp
namespace Game.Core;

public enum LiveStatus
{
    Dead,
    Weak,
    Healthy
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/Program.cs
````csharp
namespace Game.Core;

[Atomicable]
public static class Program{
    [Atomic]
    public static void Main(string[] args)
    {
        var jayPlayer = new Role
        {
            RoleBasicInfo = new RoleBasicInfo
            {
                Name = "jay",
                Type = RoleType.Player,
            },
            Attrs = new RoleAttributes
            {
                Blood = new RoleAttribute
                {
                    OriginalAmount = 10000m,
                    Buff = BuffProvider.Create(2m),
                },
                Attack = new RoleAttribute
                {
                    OriginalAmount = 100m,
                    Buff = BuffProvider.Create(2m),
                },
                Defense = new RoleAttribute
                {
                    OriginalAmount = 100m,
                    Buff = BuffProvider.Create(2m),
                },
            }
        };
    }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/Role.cs
````csharp
namespace Game.Core;

public record class Role
{
    public required RoleBasicInfo RoleInfo { get; init; }
    public required RoleAttributes Attrs { get; init; }
    public LiveStatus LiveStatus { get; private set; } = LiveStatus.Healthy;

    public bool IsAlly(Role other)
    {
        return this.RoleInfo.Type == other.RoleInfo.Type;
    }
    /// <summary>
    /// suffer from <paramref name="other"/>
    /// </summary>
    /// <param name="other">other role</param>
    public void Suffer(Role other)
    {
        /// logic of suffer

        if (IsAlly(other))
        {
            return;
        }

        // formula of attack
        decimal sufferedAmount =
            new RoleAttributeUtilityService(other.Attrs.Attack).GetMultipliedAmount() -
            new RoleAttributeUtilityService(this.Attrs.Defense).GetMultipliedAmount();
        sufferedAmount = Math.Min(sufferedAmount, this.Attrs.Blood.CurrentAmount);

        this.Attrs.Blood.CurrentAmount -= sufferedAmount;

        UpdateLiveStatus();
    }

    public void UpdateLiveStatus()
    {
        if (this.Attrs.Blood.CurrentAmount <= 0m)
        {
            this.LiveStatus = LiveStatus.Dead;
        }
        else if (this.Attrs.Blood.CurrentAmount >= this.Attrs.Blood.OriginalAmount * 0.5m)
        {
            this.LiveStatus = LiveStatus.Healthy;
        }
        else
        {
            this.LiveStatus = LiveStatus.Weak;
        }
    }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/RoleAttribute.cs
````csharp
namespace Game.Core;

public record class RoleAttribute
{
    [Dependable]
    [Range(0,10000000000000m)]
    public required decimal OriginalAmount {get;init;}
    [Depends(DependsOn:nameof(OriginalAmount))]
    [Default(ValueReferenceTo=nameof(OriginalAmount))]
    [Cant(Functionality="Initialization")]
    public decimal CurrentAmount { get; private set; }
    public required BuffBase? Buff {get;init;}
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/RoleAttributes.cs
````csharp
namespace Game.Core;

public record class RoleAttributes
{
    public required RoleAttribute Blood { get; init; }
    public required RoleAttribute Attack { get; init; }
    public required RoleAttribute Defense { get; init; }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/RoleAttributeUtilityService.cs
````csharp
namespace Game.Core;

[Atomicable]
public class RoleAttributeUtilityService(RoleAttribute roleAttribute)
{
    [Atomic]
    private readonly RoleAttribute _roleAttribute = roleAttribute;
    public bool HasNoBuff => _roleAttribute?.Buff != null; // atomic // implicitly marked with [Atomic] due to `_roleAttribute`
    public bool HasBuff => !HasNoBuff && _roleAttribute.Buff.BuffEffectMultiplier > 0 && _roleAttribute.Buff.Type == BuffType.Buff; // atomic // implicitly marked with [Atomic] due to `_roleAttribute`
    public bool HasDebuff => !HasNoBuff && _roleAttribute.Buff.BuffEffectMultiplier > 0 && _roleAttribute.Buff.Type == BuffType.Debuff; // atomic // implicitly marked with [Atomic] due to `_roleAttribute`
    public decimal GetMultipliedAmount(){

        int sign = HasBuff ? 1 : 0; // atomic // due to `HasBuff` and which is implicitly marked with [Atomic]
        return ((decimal)sign) * _roleAttribute.CurrentAmount *  _roleAttribute.Buff.BuffEffectMultiplier; // atomic 
    }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/RoleBasicInfo.cs
````csharp
namespace Game.Core;

public record class RoleBasicInfo
{
    public required string Name { get; init; }
    public required RoleType Type { get; init; }
}
````

## File: Examples/Ex1/Ex1-4/Game.Core/RoleType.cs
````csharp
namespace Game.Core;
public enum RoleType
{
    Monster,
    Player
}
````

## File: keywords/atomic/atomic.md
````markdown
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
````

## File: keywords/atomic/Atomicable.md
````markdown
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
````

## File: keywords/Depends/Depends.md
````markdown
# Depends
## Info
Idea came up with at:

2026/07/01 14:27 when I wrote an example.

## motivation
I want to simplify the initialization the property through 

from class constructor to other properties,

making it more prettier.

I thought

it is allowed to initialize property using `init` and 

it is also allowed to initialize property (for not getter-setters, getter-inititializers) by assigning it to other property in secondary constructor.

Why is it not allowed to initialize a property (for getter-setters or getter-inititializers ) simply by assigning it to other property in secondary constructor.

## usage
To use it,

you have to create a relationship from the property (for getter-setters or getter-inititializers) you want to be initialized (e.g. `CurrentAmount` in `RoleAttribute`) 

to the property used as a source (e.g. `OriginalAmount` in `RoleAttribute`) first.

To create the relationship,

you have to make the source dependable (`[Dependable]` Attribute), adding it into `Member Dependency Tree` of `RoleAttribute`, for example.

then connects the property to the source (add the source in `DependsOn` of `[Depends]` Attribute)

After creating the relationship,

you have to (dynamically) set default value to the value of source property (e.g. `OriginalAmount`) after initialization (use `[Default]` Attribute)

Lastly, you have to ban the functionality about explicit initialization of the property (e.g. `CurrentAmount` ) (use `[Cant(Functionality="Initialization")]` )

enforcing one can't explicitly assign value to the property (e.g. `CurrentAmount`) when instantiating it.

See [`RoleAttribute`](../../Examples/Ex1/Ex1-4/Game.Core/RoleAttribute.cs) class on the [project](../../Examples/Ex1/Ex1-4/Game.Core/Game.Core.csproj)
````

## File: repomix.config.json
````json
{
  "$schema": "https://repomix.com/schemas/latest/schema.json",
  "input": {
    "maxFileSize": 52428800
  },
  "output": {
    "filePath": "Idea-About-ProgrammingLanguages-CSharp-repomix-output.md",
    "style": "markdown",
    "parsableStyle": false,
    "fileSummary": true,
    "directoryStructure": true,
    "files": true,
    "removeComments": false,
    "removeEmptyLines": false,
    "compress": false,
    "topFilesLength": 5,
    "showLineNumbers": false,
    "truncateBase64": false,
    "copyToClipboard": false,
    "includeFullDirectoryStructure": false,
    "tokenCountTree": false,
    "git": {
      "sortByChanges": true,
      "sortByChangesMaxCommits": 100,
      "includeDiffs": false,
      "includeLogs": false,
      "includeLogsCount": 50
    }
  },
  "include": [],
  "ignore": {
    "useGitignore": true,
    "useDotIgnore": true,
    "useDefaultPatterns": true,
    "customPatterns": []
  },
  "security": {
    "enableSecurityCheck": true
  },
  "tokenCount": {
    "encoding": "o200k_base"
  }
}
````
