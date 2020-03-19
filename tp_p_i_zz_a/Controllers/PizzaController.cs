using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tp_p_i_zz_a.Controllers
{
    public class PizzaController : Controller

        
    {
        private static List<Pizza> ListePizzas;
        private static List<Pate> listPates;
        private static List<Ingredient> listIngredient;
        public PizzaController()
        {
            listPates = Pizza.PatesDisponibles;
            listIngredient = Pizza.IngredientsDisponibles;

            if (ListePizzas == null)
            {
                ListePizzas = new List<Pizza>
            {
               new Pizza
               {
                   Id=1,
                   Nom="Reine",
                   Pate=listPates.ElementAt(0),
                   Ingredients= new List<Ingredient>
                   {
                       listIngredient.ElementAt(2),
                       listIngredient.ElementAt(0),
                       listIngredient.ElementAt(1),
                       listIngredient.ElementAt(2)
                   }


               },
               new Pizza
               {
                   Id=2,
                   Nom="Saumon",
                   Pate= listPates.ElementAt(1),
                   Ingredients= new List<Ingredient>
                   {
                       listIngredient.ElementAt(2),
                       listIngredient.ElementAt(5)
                   }
               }

            };
            }

        }

       

        private Ingredient getIngredientById(int id)
        {
            return listIngredient.FirstOrDefault(i => i.Id == id);
        }

      

        private Pate getPateById(int id)
        {
            return listPates.FirstOrDefault(p => p.Id == id);
        }

        private Pizza getPizzaById(int id)
        {
            return ListePizzas.FirstOrDefault(p => p.Id == id);
        }

        // GET: Pizza
        public ActionResult Index()
        {
            return View(ListePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = getPizzaById(id);
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(Pizza pizza)
        {
            try
            {
 

                pizza.Pate = getPateById(pizza.Pate.Id);
                foreach (var ingredient in pizza.SelectedIngredients)
                {
                    pizza.Ingredients.Add(listIngredient.FirstOrDefault(i => i.Id.ToString() == ingredient));
                }
                ListePizzas.Add(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = getPizzaById(id);
            pizza.SelectedIngredients.Clear();
            foreach(var i in pizza.Ingredients)
            {
                pizza.SelectedIngredients.Add(i.Id.ToString());
            }
            return View(pizza);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(Pizza pizza)
        {
            try
            {
                Pizza pizzaDB = getPizzaById(pizza.Id);
                pizzaDB.Nom = pizza.Nom;
                pizzaDB.Pate = getPateById(pizza.Pate.Id);

                pizzaDB.Ingredients.Clear();
                foreach (var ingredient in pizza.SelectedIngredients)
                {
                    pizzaDB.Ingredients.Add(listIngredient.FirstOrDefault(i => i.Id.ToString() == ingredient));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = getPizzaById(id);
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var pizza = getPizzaById(id);
                ListePizzas.Remove(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
