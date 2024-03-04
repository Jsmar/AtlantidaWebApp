using AtlantidaWebApi.DC;
using AtlantidaWebApi.Models;
using Microsoft.EntityFrameworkCore;
using ClosedXML;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;

namespace AtlantidaWebApi.Services
{

    public interface IService_Transaccion
    {

        List<Transaccion> Transaccion_ALL(int id);
        List<Transaccion> Transaccion_CARGOS(int id);
        List<Transaccion> Transaccion_ABONOS(int id);
        string Transaccion_INS(Transaccion model, int id);
        

    }
    public class Transaccion_Service : IService_Transaccion
    {
        private readonly AppDataContext _context;
        public Transaccion_Service(AppDataContext context)
        {
            _context = context;
        }
        #region SELECT ABONOS
        public List<Transaccion> Transaccion_ABONOS(int id)
        {
            var result = _context.Transacciones.Where(s => s.TipoOperacion == "A" && s.IdTarjeta == id).OrderByDescending(x => x.Fecha).ToList();
            return result;
        }
        #endregion

        #region SELECT ALL
        public List<Transaccion> Transaccion_ALL(int id)
        {
            var result = _context.Transacciones.Where(s => s.IdTarjeta == id).ToList(); ;
            return result;
        }
        #endregion

        #region SELECT CARGOS
        public List<Transaccion> Transaccion_CARGOS(int id)
        {
            var result = _context.Transacciones.Where(s => s.TipoOperacion == "C" && s.IdTarjeta == id).OrderByDescending(x => x.Fecha).ToList();
            return result;
        }
        #endregion

        #region INSERT
        public string Transaccion_INS(Transaccion model, int id)
        {
            var tarjeta = _context.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return "Id de tarjeta no encontrado";
            }
            model.IdTarjeta = tarjeta.Id;
            model.NumeroTarjeta = tarjeta.NumeroTarjeta;
            if (model.TipoOperacion == "A" && (model.Monto + tarjeta.SaldoDisponible) < tarjeta.LimiteCredito )
            {
                tarjeta.SaldoActual = tarjeta.SaldoActual - model.Monto;
                tarjeta.SaldoDisponible = tarjeta.SaldoDisponible + model.Monto;
                _context.Add(model);
                _context.SaveChanges();
                return "Abono Insertado";

            }
            else if(model.TipoOperacion == "C" && tarjeta.SaldoDisponible >= model.Monto)
            {
                tarjeta.SaldoActual = tarjeta.SaldoActual + model.Monto;
                tarjeta.SaldoDisponible = tarjeta.SaldoDisponible - model.Monto;
                _context.Add(model);
                _context.SaveChanges();
                return "Cargo Insertado";

            }
            return "Datos no validos";
        }

        #endregion

        #region EXCEL

       

        #endregion 
    }
}
