using System.ComponentModel;

namespace AtlantidaWebApp.Models
{
    public class TransaccionViewModel
    {
        public int Id { get; set; }
        [DisplayName("Número de Tarjeta")]
        public string NumeroTarjeta { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime Fecha { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Tipo de Operacion")]
        public string TipoOperacion { get; set; }
        [DisplayName("Monto")]
        public decimal Monto { get; set; }
        public int IdTarjeta { get; set; }
    }
}
