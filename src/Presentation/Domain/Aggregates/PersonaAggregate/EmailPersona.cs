namespace MsServiceApp.Domain
{
    public class EmailPersona : Entity
    {
        public Guid IdPersona { get; private set; }
        public string Email { get; private set; }
        public bool EsPrincipal { get; private set; }
        public Persona Persona{ get; private set;}
        public void Registrar(Guid idPersona, string email, bool esPrincipal)
        {
            IdPersona = idPersona;
            Email = email;
            EsPrincipal = esPrincipal;
        }
    }
}