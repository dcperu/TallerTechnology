using Application.Core.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace TTService.Controllers
{
    public class CarController : ApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICarService _carService;
        public CarController(IHttpContextAccessor contextAccessor, ICarService carService)
        {
            _contextAccessor = contextAccessor;
            _carService = carService;
        }


        [System.Web.Http.HttpGet]
        public async Task<ActionResult<ToViewCarDTO>> GetAll()
        {
            return _carService.GetAll();
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
