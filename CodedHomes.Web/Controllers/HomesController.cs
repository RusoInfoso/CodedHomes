using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodedHomes.Data;
using CodedHomes.Web.ViewModels;

namespace CodedHomes.Web.Controllers
{
    [Authorize]
    public class HomesController : Controller
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var vm = new HomesListViewModel();
            var query = _unit.Homes.GetAll().OrderByDescending(s => s.Price);

            vm.Homes = query.ToList();

            return View("Index", vm);
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}