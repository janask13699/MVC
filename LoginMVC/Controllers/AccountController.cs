using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        TwilightUsersEntities1 db=new TwilightUsersEntities1();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegister ur) 
        {
            if (ModelState.IsValid) 
            {
                if (db.UserRegisters.Any(x => x.Email == ur.Email))
                {
                    ViewBag.Message = "Email Already Registered";
                }
                else
                {
                    db.UserRegisters.Add(ur);
                    db.SaveChanges();
                    Response.Write("<script>alert('Registration Successfully Done')</script>");
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MyLogin l) 
        {
            var query = db.UserRegisters.SingleOrDefault(m=>m.Email == l.Email && m.PassWords==l.Password);
            if (query != null)
            {
                Response.Write("<script>alert('User Login Successfully Done')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username and Password')</script>");
            }
            return View();

        }
    }
   
}