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