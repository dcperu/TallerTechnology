using Application.Core.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace TTWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {        
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public List<ToViewCarDTO> GetAll()
        {
            return _carService.GetAll();
        }
    }
}
