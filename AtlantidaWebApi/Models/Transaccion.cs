using System.ComponentModel.DataAnnotations.Schema;

namespace AtlantidaWebApi.Models
{
    public class Transaccion
    {

        public int Id { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string TipoOperacion { get; set; }
        public decimal Monto { get; set; }
        public int IdTarjeta { get; set; }
    }
}
