using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IOwnerRepository _ownerRepo;
        private readonly INeighborhoodRepository _neighborhoodRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(
            IWalkerRepository walkerRepository,
            IOwnerRepository ownerRepository,
            INeighborhoodRepository neighborhoodRepository
            )
        {
            _walkerRepo = walkerRepository;
            _ownerRepo = ownerRepository;
            _neighborhoodRepo = neighborhoodRepository;
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

        // GET: Walkers
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            Owner currentOwner = _ownerRepo.GetOwnerById(ownerId);
            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(currentOwner.Neighborhood.Id);

            return View(walkers);
        }

        // GET: Walkers/Details/
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id); 
            List<Walk> walks = _walkerRepo.GetWalksByWalkerId(id);

            // Initiate variable to hold total seconds the walker walked
            int secondsWalked = 0;

            foreach(Walk walk in walks)
            {
                secondsWalked += walk.Duration;
            }
            walker.TotalWalkTime = DateTime.Today.Add(TimeSpan.FromSeconds(secondsWalked)).ToString("hh:mm");
            WalkerProfileViewModel vm = new WalkerProfileViewModel()
            {
                Walker = walker,
                Walks = walks
            };

            return View(vm);          
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
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

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
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

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
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
