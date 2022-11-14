using DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using TTWebApp.Models;

namespace TTWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string Baseurl = "https://localhost:7011/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<ToViewCarDTO> CarInfo = new List<ToViewCarDTO>();
            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();             
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                HttpResponseMessage Res = await client.GetAsync("api/Car/GetAll");                
                if (Res.IsSuccessStatusCode)
                {                    
                    var CarResponse = Res.Content.ReadAsStringAsync().Result;                 
                    CarInfo = JsonConvert.DeserializeObject<List<ToViewCarDTO>>(CarResponse);
                }
                
                List<CarViewModel> carModel = CarInfo.Select(c => new CarViewModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Doors = c.Doors,
                    Color = c.Color
                }).ToList();

                return View(carModel);
            }
        }

        [HttpPost]
        public IActionResult Guess(decimal price)
        {
            if(price <= 5000)
            {
                return RedirectToAction("Great");
            }
            return RedirectToAction("Index");
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Great()
        {
            return View();
        }
    }
}