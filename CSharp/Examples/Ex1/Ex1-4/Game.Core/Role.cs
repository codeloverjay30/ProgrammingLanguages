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