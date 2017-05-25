using MeDevolve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeDevolve.Controllers
{
    public class HomeController : Controller
    {
        private MeDevolveContext db = new MeDevolveContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Emprestimoes.ToList());
        }
    }
}