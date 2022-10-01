using User.Domain.Entities.Interfaces;

namespace User.Domain.Entities;

public class UserPolicyEntity: IMutableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public List<PolicyEntity> Policies { get; set; } = new List<PolicyEntity>();
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}