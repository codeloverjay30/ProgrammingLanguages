namespace Game.Core;

public record class RoleBasicInfo
{
    public required string Name { get; init; }
    public required RoleType Type { get; init; }
}