namespace MsServiceApp.Domain
{
    public class TipoDocumentoIdentidad : Entity
    {
        public string Nombre { get; private set; }    
        public string Descripcion { get; private set; }  
        
        public ICollection<Persona> Personas { get; private set; } = new List<Persona>();  
    }
}