using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewCoffeeShop.Models;
using NewCoffeeShop.Views.Home;

namespace NewCoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        List<Items> ItemList = new List<Items>() {

           new Items("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
           new Items("Latte","Milk, Coffee", 1.99),
           new Items("Coffee","Coffee, Water", 1.00),
           new Items("Tea", "Black Tea", 1.00),
           new Items("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99)
       };

        List<Items> ShoppingCart = new List<Items>();
        List<User> UsersList = new List<User>();

        public ActionResult Index()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult RegisterUsers(User newUser)
        {
            
            Session["CurrentUser"] = newUser;
            ViewBag.CurrentUser = newUser;
            if (Session["Resgisterd"] == null)
            {
                Session["Resgisterd"] = UsersList;
                UsersList.Add(newUser);
                
            }
            else
            {
                UsersList = (List<User>)Session["Resgisterd"];
                
            }
            ViewBag.Resgisterd = newUser;
            return View();
        }

        public ActionResult Confirn()
        {

            return View();
        }

        public ActionResult LoginPage(User newUser)
        {
            //this is were we'er using the three session steps to register a user
           
            if (UsersList.Contains(newUser))
            {
                Session["CurrentUser"] = newUser;
                return View();             
            }
            return View();
        }

        public ActionResult Welcome(User newUser)
        {
            if (Session["CurrentUser"] != null)
            {
                newUser = (User)Session["CurrentUser"];
                ViewBag.CurrentUser = newUser;
                return RedirectToAction ("LoginPage");
            }

            else
            {
                if (ModelState.IsValid)
                {                 
                    ViewBag.CurrentUser = newUser;
                    Session["CurrentUser"] = newUser;
                    return View();
                }
                else
                {                
                   return View("RegisterUsers");
                }
            }
        }
       
        public ActionResult LogOut()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            Session.Remove("CurrentUser");
            return View();
        }

        public ActionResult ListItems()
        {
            ViewBag.ItemList = ItemList;
            return View();
        }

        public ActionResult AddItem(string itemName)
        {
            if(Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Items>)Session["ShoppingCart"];
            }
            foreach(Items item in ItemList)
            {
                if(item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }
            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }

        public ActionResult Error()
        {
            ViewBag.ErrorMessage = "Registration failed. Try again.";
            return View();
        }

        public ActionResult Cart()
        {
            ShoppingCart = (List<Items>)Session["ShoppingCart"];
            ViewBag.ShoppingCart = ShoppingCart;
            return View();
        }

        public ActionResult DeleteItem(string itemName)
        {
            int i = 0;
            if (Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Items>)Session["ShoppingCart"];
            }
            foreach (Items item in ShoppingCart)
            {
                if (item.ItemName == itemName)
                {
                    break;
                }
                i++;
            }
            ShoppingCart.RemoveAt(i);
            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("Cart");
        }
    }
}