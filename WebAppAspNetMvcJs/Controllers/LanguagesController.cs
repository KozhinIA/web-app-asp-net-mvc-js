﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcJs.Models;

namespace WebAppAspNetMvcJs.Controllers
{
    public class LanguagesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new LibraryContext();
            var languages = db.Languages.ToList();

            return View(languages);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var language = new Language();
            return View(language);
        }

        [HttpPost]
        public ActionResult Create(Language model)
        {
            var db = new LibraryContext();

            if (!ModelState.IsValid)
            {
                var languages = db.Languages.ToList();
                ViewBag.Create = model;
                return View("Index", languages);
            }

                         

            db.Languages.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Languages/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new LibraryContext();
            var language = db.Languages.FirstOrDefault(x => x.Id == id);
            if (language == null)
                return RedirectPermanent("/Languages/Index");

            db.Languages.Remove(language);
            db.SaveChanges();

            return RedirectPermanent("/Languages/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new LibraryContext();
            var language = db.Languages.FirstOrDefault(x => x.Id == id);
            if (language == null)
                return RedirectPermanent("/Languages/Index");

            return View(language);
        }

        [HttpPost]
        public ActionResult Edit(Language model)
        {
            var db = new LibraryContext();
            var language = db.Languages.FirstOrDefault(x => x.Id == model.Id);
            if (language == null)
                ModelState.AddModelError("Id", "Жанр не найден");

            if (!ModelState.IsValid)
            {
                var languages = db.Languages.ToList();
                ViewBag.Create = model;
                return View("Index", languages);
            }

            MappingLanguage(model, language);

            db.Entry(language).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Languages/Index");
        }

        private void MappingLanguage(Language sourse, Language destination)
        {
            destination.Name = sourse.Name;
        }
    }
}