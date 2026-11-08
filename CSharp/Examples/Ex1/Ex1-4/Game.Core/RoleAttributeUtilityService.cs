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