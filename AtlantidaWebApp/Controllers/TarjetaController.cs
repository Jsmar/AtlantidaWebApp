using AtlantidaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AtlantidaWebApp.Controllers
{
    public class TarjetaController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7042/api");
        private readonly HttpClient _client;

        public TarjetaController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<TarjetaViewModel> tarjetaList = new List<TarjetaViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/tarjeta/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                tarjetaList = JsonConvert.DeserializeObject<List<TarjetaViewModel>>(data);
            }

            return View(tarjetaList);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        #region Nueva tarjeta
        [HttpPost]
        public IActionResult Create(TarjetaViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/tarjeta/Post", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Tarjeta Creada";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessagge"] = ex.Message;
                return View();
            }
            return View();
        }
        #endregion

        #region Busqueda de trajeta a editar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                TarjetaViewModel tarjeta = new TarjetaViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/tarjeta/Get/" + id).Result;


                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    tarjeta = JsonConvert.DeserializeObject<TarjetaViewModel>(data);
                }
                return View(tarjeta);
            }
            catch (Exception ex)
            {
                TempData["errorMessagge"] = ex.Message;
                return View();
            }

        }
        #endregion

        #region Edicion Tarjeta
        [HttpPost]
        public IActionResult Edit(TarjetaViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/tarjeta/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Datos Actualizados";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessagge"] = ex.Message;
                return View();
            }
            return View();
        }
        #endregion

        #region Consulta de transacciones 
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                TarjetaViewModel tarjeta = new TarjetaViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/tarjeta/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string dataTarjeta = response.Content.ReadAsStringAsync().Result;
                    tarjeta = JsonConvert.DeserializeObject<TarjetaViewModel>(dataTarjeta);
                }

                HttpResponseMessage responseTransaccion = _client.GetAsync(_client.BaseAddress + "/transaccion/GetTransacciones/" + id).Result;

                if (responseTransaccion.IsSuccessStatusCode)
                {
                    string dataTransaccion = responseTransaccion.Content.ReadAsStringAsync().Result;
                    List<TransaccionViewModel> listaTransacciones = JsonConvert.DeserializeObject<List<TransaccionViewModel>>(dataTransaccion);
                    tarjeta.Transacciones = listaTransacciones;
                }

                
                return View(tarjeta);
            }
            catch (Exception ex)
            {
                TempData["errorMessagge"] = ex.Message;
                return View();
            }
        }
        #endregion

        #region Llenado de EDC
        [HttpGet]
        public IActionResult DetailsTransacciones(int id)
        {
            try
            {
                TarjetaViewModel tarjeta = new TarjetaViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/tarjeta/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string dataTarjeta = response.Content.ReadAsStringAsync().Result;
                    tarjeta = JsonConvert.DeserializeObject<TarjetaViewModel>(dataTarjeta);
                }

                HttpResponseMessage responseTransaccion = _client.GetAsync(_client.BaseAddress + "/transaccion/GetTransaccionesCargos/" + id).Result;

                if (responseTransaccion.IsSuccessStatusCode)
                {
                    string dataTransaccion = responseTransaccion.Content.ReadAsStringAsync().Result;
                    List<TransaccionViewModel> listaTransacciones = JsonConvert.DeserializeObject<List<TransaccionViewModel>>(dataTransaccion);
                    tarjeta.Transacciones = listaTransacciones;
                }


                return View(tarjeta);
            }
            catch (Exception ex)
            {
                TempData["errorMessagge"] = ex.Message;
                return View();
            }
        }
        #endregion
    }
}
