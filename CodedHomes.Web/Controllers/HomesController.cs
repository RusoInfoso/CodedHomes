﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodedHomes.Data;
using CodedHomes.Models;
using CodedHomes.Web.ViewModels;

namespace CodedHomes.Web.Controllers
{
    [Authorize]
    public class HomesController : Controller
    {
        private readonly ApplicationUnit _unit = new ApplicationUnit();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var vm = new HomesListViewModel();
            var query = _unit.Homes.GetAll().OrderByDescending(s => s.Price);

            vm.Homes = query.ToList();

            return View("Index", vm);
        }

        public ActionResult New()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.IsNew = true;


            return View("Home", vm);
        }

        [ActionName("Edit")]
        public ActionResult Get(int id)
        {
            HomeViewModel vm = new HomeViewModel { Home = _unit.Homes.GetById(id) };

            if (vm.Home != null)
            {
                return View("Home", vm);
            }

            return View("NotFound");
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image, int id)
        {
            JsonResult result;
            Random rand = new Random();

            string unique = rand.Next(1000000).ToString();
            string ext = Path.GetExtension(image.FileName).ToLower();
            string fileName = string.Format("{0}-{1}{2}", id, unique, ext);
            string path = Path.Combine(HttpContext.Server.MapPath(Config.ImagesFolderPath), fileName);

            if (ext == ".png" || ext == ".jpg")
            {
                Home home = _unit.Homes.GetById(id);

                if (home != null)
                {
                    home.ImageName = fileName;
                    _unit.Homes.Update(home);
                    _unit.SaveChanges();

                    image.SaveAs(path);
                    result = this.Json(new
                    {
                        imageUrl = string.Format("{0}{1}",
                        Config.ImagesUrlPrefix, fileName)
                    });
                }
                else
                {
                    result = this.Json(new
                    {
                        status = "error",
                        statusText =
                            string.Format("There is no home with the Id of " +
                                "'{0}' in the system.", id)
                    });
                }
            }
            else
            {
                result = this.Json(new
                {
                    status = "error",
                    statusText = "Unsupported image type. Only .png or " +
                        ".jpg files are acceptable."
                });
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}