using FeedbackMS.DTOs;
using FeedbackMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackMS.Controllers
{
    public class LoginController : Controller
    {
        FeebackMSEntities db = new FeebackMSEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Index(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Username.Equals(loginDTO.Username) && u.Password.Equals(loginDTO.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var loggedId = (from u in db.Users
                                    where u.Username.Equals(loginDTO.Username)
                                    select u.Id).SingleOrDefault();
                    Session["loggedId"] = loggedId;
                    Session["User"] = loginDTO;
                    Session["Username"] = loginDTO.Username;
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else { return View(loginDTO); }
        }
    }
}