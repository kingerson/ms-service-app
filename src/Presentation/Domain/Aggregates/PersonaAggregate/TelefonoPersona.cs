namespace MsServiceApp.Domain
{
    public class TelefonoPersona : Entity
    {
        public Guid IdPersona { get; private set; }
        public string NumeroTelefono { get; private set; }    
        public bool EsPrincipal { get; private set; }   
        public Persona Persona{ get; private set;}

        public void Registrar(Guid idPersona,string numeroTelefono, bool esPrincipal)
        {
            IdPersona = idPersona;
            EsPrincipal = esPrincipal;
            NumeroTelefono = numeroTelefono;
        }  
    }
}