using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheesesMVC.Models
{
    public class CheeseData
    {
        static private List<Cheese> cheeses = new List<Cheese>();
        //get all of data to the methods
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }


        //add method
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        //remove method
        public static void Remove(int id)
        {
            Cheese cheesetoRemove = GetById(id);
            cheeses.Remove(cheesetoRemove);
        }

        //getbyid
        public static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.cheeseId == id);
        }
    }
}
