namespace MsServiceApp.Domain
{
    public class PersonaMetadata : Entity
    {
        public Guid IdPersona { get; private set; }
        public string Key { get; private set; }    
        public string Value { get; private set; }    
    }
}