using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheesesMVC.Models;
using CheesesMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheesesMVC.Controllers

{
    public class CheeseController : Controller
    {

        


        // GET: /<controller>/
        public IActionResult Index()
        {
           
            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                };
                CheeseData.Add(newCheese);



                return Redirect("/Cheese");
            }
            //add new cheese to previous cheeses

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheese = CheeseData.GetAll;
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            //todo-  remove cheeses from list
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            
            return Redirect("/");
        }
        
    }
}
