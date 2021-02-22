using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] // show the ampt page first
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost] // show the ampt page first
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel, string email, string EMAIL, string FName, string LastName)
        {
            /*
             * !!!Important in MVC
                Receive data from view to controller
                "Model Binding"
                Form, it will look for input elements names and if those names match with
            the names of the action method model properties
            then it will automatically map that data
             * 
             *  a control with name=email. E.g., abc@abc.com passed to the model (case-insisitive)
             *  UserRegisterRequestModel => Email. 
             */

            if (!ModelState.IsValid)
            {
                return View();
            }

            //only when every validation passes make sure you save to database
            // call our User Service to  save to db
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
