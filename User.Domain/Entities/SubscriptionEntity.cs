namespace User.Domain.Entities;

public class SubscriptionEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid UserId { get; set; }
    
    public SubscriptionLevel SubscriptionLevel { get; set; }
    
}