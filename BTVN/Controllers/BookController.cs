using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTVN.Models;

namespace BTVN.Controllers
{
    public class BookController : Controller
    {
        QuanLySachDataContext db = new QuanLySachDataContext();

        // GET: Book
        public ActionResult Index()
        {
            var all = from b in db.Books select b;
            return View(all);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook(FormCollection bookinfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Book newbook = new Book();
                    newbook.Author = bookinfo["Author"];
                    newbook.Title = bookinfo["Title"];
                    newbook.Description = bookinfo["Description"];
                    newbook.ImageCover = bookinfo["ImageCover"];
                    newbook.Price = Int32.Parse(bookinfo["Price"]);
                    db.Books.Add(newbook);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "Input Model Not Valid");
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditBook(int id)
        {

            //Check
            if (id == null)
            {
                return HttpNotFound();
            }
            var book = db.Books.Find(id);

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(FormCollection bookinfo, int id)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    var book = db.Books.Find(id);

                    book.Author = bookinfo["Author"];
                    book.Title = bookinfo["Title"];
                    book.Description = bookinfo["Description"];
                    book.ImageCover = bookinfo["ImageCover"];
                    book.Price = Int32.Parse(bookinfo["Price"]);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return HttpNotFound();
                }
            }
            else

            {
                ModelState.AddModelError("", "Input Model Not Valid");
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            return View(book);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}