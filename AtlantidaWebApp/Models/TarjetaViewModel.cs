using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlantidaWebApp.Models
{
    public class TarjetaViewModel
    {

        public int Id { get; set; }
        [DisplayName("Nombres")]
        public string Nombres { get; set; }
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        [DisplayName("Número de Tarjeta")]
        public string NumeroTarjeta { get; set; }
        [DisplayName("Saldo Actual")]
        public decimal SaldoActual { get; set; }
        [DisplayName("Limite de Crédito")]
        public decimal LimiteCredito { get; set; }
        [DisplayName("Saldo Disponible")]
        public decimal SaldoDisponible { get; set; }
        [DisplayName("Porcentaje de Interés")]
        public decimal PorcentajeInteres { get; set; }
        [DisplayName("Porcentaje de Saldo Minimo")]
        public decimal PorcentajeSaldoMinimo { get; set; }
        [DisplayName("Interés Bonificable")]
        public decimal InteresBonificable { get; set; }
        [DisplayName("Cuota Mínima")]
        public decimal CuotaMinima { get; set; }
        [DisplayName("Pago al contado con intereses")]
        public decimal PagoContadoConIntereses { get; set; }
        [DisplayName("Transacciones")]
        public List<TransaccionViewModel> Transacciones { get; set; }



    }
}
