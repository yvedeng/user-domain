namespace User.Domain.Entities.Interfaces;

public interface IMutableEntity: IEntity
{
    public DateTime LastUpdatedAt { get; set; }
}