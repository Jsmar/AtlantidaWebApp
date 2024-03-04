using AtlantidaWebApi.DC;
using AtlantidaWebApi.Models;

namespace AtlantidaWebApi.Services
{


    public interface IService_Tarjeta
    {

        List<Tarjeta> Tarjeta_ALL();
        Tarjeta Tarjeta_FIND(int id);
        string Tarjeta_INS(Tarjeta model);
        string Tarjeta_UPD(Tarjeta model);
        string Tarjeta_DEL(int id);

    }
    public class Tarjeta_Service : IService_Tarjeta
    {

        private readonly AppDataContext _context;
        public Tarjeta_Service(AppDataContext context)
        {
            _context = context;
        }


        #region SELECT
        public List<Tarjeta> Tarjeta_ALL()
        {
            var tarjetas = _context.Tarjetas.ToList();
            return tarjetas;
        }
        #endregion

        #region SELECT BY ID
        public Tarjeta Tarjeta_FIND(int id)
        {
            var tarjeta = _context.Tarjetas.Find(id);
            tarjeta.InteresBonificable = tarjeta.SaldoActual * (tarjeta.PorcentajeInteres / 100 );
            tarjeta.CuotaMinima = tarjeta.SaldoActual * (tarjeta.PorcentajeSaldoMinimo / 100 );
            tarjeta.PagoContadoConIntereses = tarjeta.SaldoActual + tarjeta.InteresBonificable;
            return tarjeta;
        }
        #endregion


        #region INSERT
        public string Tarjeta_INS(Tarjeta model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return "Tarjeta Creada";
        }
        #endregion


        #region UPDATE
        public string Tarjeta_UPD(Tarjeta model)
        {
            var tarjeta = _context.Tarjetas.Find(model.Id);
            if (tarjeta == null)
            {
                return "Id de tarjeta no encontrado";
            }
            tarjeta.Nombres = model.Nombres;
            tarjeta.Apellidos = model.Apellidos;
            tarjeta.LimiteCredito = model.LimiteCredito;
            tarjeta.NumeroTarjeta = model.NumeroTarjeta;
            tarjeta.PorcentajeInteres = model.PorcentajeInteres;
            tarjeta.PorcentajeSaldoMinimo   = model.PorcentajeSaldoMinimo;

            _context.SaveChanges();
            return "Tarjeta actualizada";
        }
        #endregion

        #region DELETE
        public string Tarjeta_DEL(int id)
        {
            var tarjeta = _context.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return "Tarjeta no encontrada";
            }
            _context.Tarjetas.Remove(tarjeta);
            _context.SaveChanges();
            return "Tarjeta Eliminada";
        }
        #endregion
    }
}
