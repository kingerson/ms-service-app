namespace MsServiceApp.Domain
{
    using System.ComponentModel;
    public enum ProspectoDocumentosEstadoEnum
    {
        [Description("8E8929E7-5CAF-48A3-9BAB-CF4CA2C4C736")]
        PendienteDeCarga = 1,

        [Description("563158E5-3A1A-4CE1-BF10-4DC8C0CD0C4F")]
        EnviadoAprobacion = 2,

        [Description("D9259165-1A16-4847-8CE0-F7796FD4B64F")]
        AprobadoConObservacion = 3, 

        [Description("1F1CC6B3-1AF6-43F8-BC76-A55B5C270B82")]
        AprobadoSinObservacion = 4,

        [Description("AFAF0A98-3209-4A56-AE6A-BADEDC82A3F1")]
        Subsanado = 5,

        [Description("691E7DA3-BE21-4CEA-9934-C417E94BD25B")]
        Rechazado = 6,
    }
}
