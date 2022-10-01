using Permissions.AuthPolicies;
using Permissions.Permissions;
using User.Domain.Entities.Interfaces;

namespace User.Domain.Entities;

public class PolicyEntity: IMutableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public AuthPolicy PolicyName { get; set; }
    
    public List<IUserPermission> Permissions { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime LastUpdatedAt { get; set; }
}