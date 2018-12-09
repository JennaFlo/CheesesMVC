using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheesesMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheesesMVC.Controllers

{
    public class CheeseController : Controller
    {

        


        // GET: /<controller>/
        public IActionResult Index()
        {
           
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {

            //add new cheese to previous cheeses
            CheeseData.Add(new Cheese);

            

            return Redirect("/Cheese");

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
