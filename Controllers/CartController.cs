using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            //retrieve records from Cart
            List<Cart> cart = ShoppingCartData.GetCart();

            //create variable to store total price
            double total = 0;

            //add price of each item into total
            foreach (var item in cart)
            {
                total += item.Price;
            }

            //send data to View
            ViewData["total"] = total.ToString("#.##");
            ViewData["cart"] = cart;
            ViewData["images_prefix"] = "/img/";

            //html response
            return View();
        }

        //action method to receive AJAX call
        [HttpPost]
        public IActionResult RemoveItem([FromBody] Remove remove)
        {
            //store identifier as Remove object and convert to integer
            int id = Convert.ToInt32(remove.Id);

            //send identifier to database to remove record
            //ShoppingCartData.RemoveItem(id);

            return Json(new
            {
                success = true
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
