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