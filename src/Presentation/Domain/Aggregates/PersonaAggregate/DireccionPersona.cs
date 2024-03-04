namespace MsServiceApp.Domain
{
    public class DireccionPersona : Entity
    {
        public Guid IdPersona { get; private set; }
        public string Descripcion { get; private set; }  
        public bool EsPrincipal { get; private set; }
        public Persona Persona { get; private set; } 

        public void Registrar(Guid idPersona, string descripcion,bool esPrincipal)
        {
            IdPersona = idPersona;
            Descripcion = descripcion;
            EsPrincipal = esPrincipal;
        } 
    }
}