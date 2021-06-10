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
        public IActionResult Index(Animal animal)
        {
            Animal.Post(animal);
            return RedirectToAction("Index");
        }

        //GET/animals/5
        public IActionResult Details(int id)
        {
            Animal animal = Animal.GetDetails(id);
            return View(animal);
        }

        public IActionResult Edit(int id)
        {
            Animal animal = Animal.GetDetails(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(int id, Animal animal)
        {
            animal.AnimalId = id;
            Animal.Put(animal);
            return RedirectToAction("Details", id);
        }

        public IActionResult Delete(int id)
        {
            Animal.Delete(id);
            return RedirectToAction("Index");
        }
    }
}