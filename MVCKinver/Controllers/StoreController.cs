using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{
    public class StoreController : Controller
    {
        KinverEntities storeDB = new KinverEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Products").Single(g => g.Name == genre);
            return View(genreModel);
        }
        //
        // GET: /Store/Detail

        public ActionResult Details(int id)
        {
            var productModel = storeDB.Products.Find(id);
            productModel.Genre = storeDB.Genres.Find(productModel.GenreId);
            productModel.Producer = storeDB.Producers.Find(productModel.ProducerId);
            return View(productModel);
        }

        //
        //Get: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }

    }
}