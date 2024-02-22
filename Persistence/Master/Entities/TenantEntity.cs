namespace EventSourcing.Persistence.Master.Entities;

public sealed class TenantEntity : EntityBase
{
    public required string Name { get; init; }
    public required string Identifier { get; init; }
}