namespace MsServiceApp.Domain
{
    using System.ComponentModel;
    public enum FileEstadoEnum
    {
        [Description("5664FF0A-6F16-42A4-82FA-A56A44B3AA4A")]
        Pendiente = 1,

        [Description("3B8341EE-95F8-42E0-AE28-A42F469EA8DD")]
        Aprobado = 2,

        [Description("4038BE4D-CFBE-44B5-B043-078A356473DD")]
        Observado = 3,
    }
}
