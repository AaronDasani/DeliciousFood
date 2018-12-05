using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CRUDelicious.Models;

namespace CRUDelicious.Models
{
    public class DishesController:Controller
    {
        private DishContext dbContext;
        public DishesController(DishContext context)
        {   
            dbContext=context;
        }

        [HttpGet("")]
        [HttpGet("home")]

        public IActionResult index()
        {
            var allDishes=dbContext.Dishes.ToList();
            return View("index",allDishes);
        }

        [HttpGet("addDish")]
        public IActionResult newDish()
        {
            return View("newDish");
        }

        [HttpGet("edit/{dish_id}")]
        public IActionResult EditDish(Int32 dish_id)
        {
            var dishModel=dbContext.Dishes.FirstOrDefault(dish=>dish.dish_id==dish_id);
            return View("edit",dishModel);
        }


        // ----Dish page-----
        [HttpGet("dish/{dish_id}")]
        public IActionResult dish(Int32 dish_id)
        {
            var dishModel=dbContext.Dishes.FirstOrDefault(dish=>dish.dish_id==dish_id);

            return View("dish",dishModel);
        }


        [HttpGet("delete/{dish_id}")]
        public IActionResult Delete(Int32 dish_id)
        {
            
            var retrieveDish=dbContext.Dishes.FirstOrDefault(thedish=>thedish.dish_id==dish_id);
            dbContext.Remove(retrieveDish);
            dbContext.SaveChanges();
            
            return RedirectToAction("index");
        
        }


        //------------ Processing Forms----------------

        [HttpPost("addDish_processing")]
        public IActionResult Add(Dish dish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(dish);
                return RedirectToAction("newDish");
            }
            return View("newDish");
        }


        [HttpPost("editDish_processing")]
        public IActionResult Edit(Dish dish)
        {
            if (ModelState.IsValid)
            {
                var retrieveDish=dbContext.Dishes.FirstOrDefault(thedish=>thedish.dish_id==dish.dish_id);
                retrieveDish=dish;
                retrieveDish.updated_at=DateTime.Now;
                dbContext.SaveChanges();

                return RedirectToAction("EditDish");
            }
            return View("edit");
        }


    }
}