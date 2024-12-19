using FeedbackMS.DTOs;
using FeedbackMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackMS.Controllers
{
    public class RegistrationController : Controller
    {
        FeebackMSEntities db = new FeebackMSEntities();
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserDTO());
        }
        [HttpPost]
        public ActionResult Index(UserDTO u)
        {
            db.Users.Add(Convert(u));
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
        public static UserDTO Convert(User u)
        {
            return new UserDTO()
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                Type = u.Type,
                Email = u.Email,
                Password = u.Password,
            };
        }
        public static User Convert(UserDTO u)
        {
            return new User()
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                Type = u.Type,
                Email = u.Email,
                Password = u.Password,
            };
        }

    }
}