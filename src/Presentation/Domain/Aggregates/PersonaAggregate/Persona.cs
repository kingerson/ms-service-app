namespace MsServiceApp.Domain
{
    public class Persona : Entity
    {
        public string Nombre { get; private set; }    
        public string? Apellido { get; private set; }
        public Guid? IdTipoDocumento { get; private set; }
        public string? NumeroDocumento { get; set; }
        public bool ValidacionDatos { get; set; }
        public TipoDocumentoIdentidad? TipoDocumento { get; private set; }
        public ICollection<EmailPersona> EmailPersonas { get; private set; } = new List<EmailPersona>();
        public ICollection<DireccionPersona> DireccionPersonas { get; private set; } = new List<DireccionPersona>();
        public ICollection<TelefonoPersona> TelefonoPersonas { get; private set; } = new List<TelefonoPersona>();

        public void Registrar(string nombre,string apellido,Guid? tipoDocumento,string numeroDocumento)
        {
            Nombre = nombre;
            Apellido = apellido;
            NumeroDocumento = numeroDocumento;
            IdTipoDocumento = tipoDocumento;
        }
        public void RegistrarOActualizarEmailPersona(Guid idPersona, string email, bool esPrincipal)
        {
            var emailPersona = new EmailPersona();
            emailPersona.Registrar(idPersona,email,esPrincipal);
            EmailPersonas.Add(emailPersona);
        }

        public void RegistrarOActualizarDireccionPersona(Guid idPersona, string descripcion, bool esPrincipal)
        {
            var direccionPersona = new DireccionPersona();
            direccionPersona.Registrar(idPersona,descripcion,esPrincipal);
            DireccionPersonas.Add(direccionPersona);
        }

        public void RegistrarOActualizarTelefonoPersona(Guid idPersona, string numeroTelefono ,bool esPrincipal)
        {
            var telefonoPersona = new TelefonoPersona();
            telefonoPersona.Registrar(idPersona,numeroTelefono,esPrincipal);
            TelefonoPersonas.Add(telefonoPersona);
        }
    }
}