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

