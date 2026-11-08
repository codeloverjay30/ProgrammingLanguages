namespace Game.Core;
public record class BuffBase
{
    public required BuffType Type { get; init; }
    [Range(0, 10m)]
    public required decimal BuffEffectMultiplier { get; init; }
}