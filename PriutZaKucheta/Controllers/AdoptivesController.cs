using DogShelter.Abstractions;
using DogShelter.Models.Adoptive;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogShelter.Controllers
{
    public class AdoptivesController : Controller
    {
        private readonly IAdoptiveService _adoptiveService;

        public AdoptivesController(IAdoptiveService adoptiveService)
        {
            _adoptiveService = adoptiveService;
        }

        // GET: AdoptivesController
        public ActionResult Index()
        {
            var users = _adoptiveService.GetAdoptives()
                   .Select(u => new AdoptiveListingVM
                   {
                       Id = u.Id,
                       FirstName = u.FirstName,
                       LastName = u.LastName,                     
                       Phone = u.Phone,
                       BirthDate = u.BirthDate
                   }).ToList();
            //Да се инсталира Microsoft.EntityFrameworkCore.Proxies и да се включи LazyLoading
            return this.View(users);
        }

        // GET: AdoptivesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdoptivesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdoptivesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAdoptiveVM adoptive)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userIdAlreadyAdoptive = this._adoptiveService
                .GetAdoptives()
                .Any(d => d.UserId == userId);

            if (!ModelState.IsValid)
            {
                return View(adoptive);
            }
            var created = _adoptiveService.CreateAdoptive(adoptive.FirstName, adoptive.LastName, adoptive.Phone, adoptive.BirthDate, userId);


            if (created)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        // GET: AdoptivesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdoptivesController/Edit/5
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

        // GET: AdoptivesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdoptivesController/Delete/5
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
