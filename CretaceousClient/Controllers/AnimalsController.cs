using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CretaceousClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace CretaceousClient.Controllers
{
    public class AnimalsController : Controller
    {
        public IActionResult Index()
        {
            List<Animal> allAnimals = Animal.GetAnimals();
            return View(allAnimals);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Animal animal)
        {
            await Animal.Post(animal);
            return RedirectToAction("Index");
        }

        //GET/animals/5
        public IActionResult Details(int id)
        {
            Console.WriteLine($"id = {id}");
            Animal animal = Animal.GetDetails(id);
            return View(animal);
        }

        public IActionResult Edit(int id)
        {
            Animal animal = Animal.GetDetails(id);
            return View(animal);
        }

        [HttpPost]
        // This leads back to details after the edit is sent.
        public async Task<IActionResult> Details(int id, Animal animal)
        {
            animal.AnimalId = id;
            await Animal.Put(animal);
            return RedirectToAction("Details", id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await Animal.Delete(id);
            return RedirectToAction("Index");
        }
    }
}