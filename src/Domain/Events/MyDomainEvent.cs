namespace Domain.Events;

public class MyDomainEvent 

{ 
    public DateTime OccurredOn { get; } 
    
    public MyDomainEvent() 
    
    { 
        OccurredOn = DateTime.UtcNow; 
    } 
} 
 
