namespace weatherlogr.CustomAttributes;

[AttributeUsage(AttributeTargets.Class)]
public class ODataEdmDefinitionAttribute : Attribute
{
    public ODataEdmDefinitionAttribute(Type entityType)
    {
        this.EntityType = entityType;
    }
    
    public string? EntitySetName { get; set; }

    public Type EntityType { get; set; }
}