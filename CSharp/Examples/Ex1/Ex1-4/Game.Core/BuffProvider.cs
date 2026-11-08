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