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