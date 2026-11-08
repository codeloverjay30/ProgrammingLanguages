namespace Game.Core;

public record class RoleAttributes
{
    public required RoleAttribute Blood { get; init; }
    public required RoleAttribute Attack { get; init; }
    public required RoleAttribute Defense { get; init; }
}