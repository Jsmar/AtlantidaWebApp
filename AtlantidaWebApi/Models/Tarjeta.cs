using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlantidaWebApi.Models
{
    public class Tarjeta
    {

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set;}
        public string NumeroTarjeta { get; set;}
        public decimal SaldoActual { get; set;}
        public decimal LimiteCredito { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal PorcentajeInteres { get; set; }
        public decimal PorcentajeSaldoMinimo { get; set; }
        [NotMapped]
        public decimal InteresBonificable { get; set; }
        [NotMapped]
        public decimal CuotaMinima { get; set; }
        [NotMapped]
        public decimal PagoContadoConIntereses { get; set; }
        [NotMapped]
        public List<Transaccion> Transacciones { get; set; }







    }
}
