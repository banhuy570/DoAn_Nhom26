using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace TestUngDung.Areas.Admin.Controllers
{
    public class QLtkbController : Controller
    {
            private Model1 db = new Model1();

            // GET: Admin/QLDienThoai
            public ActionResult Index(int page = 1, int pagesize = 5)
            {
                var product = db.ThoiKhoaBieux;
                var model = product.OrderBy(x => x.MaTKB);
                return View(model.ToPagedList(page, pagesize));
            }
            // GET: Admin/QLDienThoai/Details/5
            public ActionResult Details(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ThoiKhoaBieu product = db.ThoiKhoaBieux.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }

            // GET: Admin/QLDienThoai/Create
            public ActionResult Create()
            {
                ViewBag.MaPMT = new SelectList(db.PhongMays, "MaPMT", "TenPMT");
                return View();
            }

            // POST: Admin/QLDienThoai/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "MaTKB,MaPMT,MaND,HocKy,MonHoc,TenGV,Thu,TuTiet,DenTiet,NgayBD,SoLuongSV")] ThoiKhoaBieu thoiKhoaBieu)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.ThoiKhoaBieux.Add(thoiKhoaBieu);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PhongMay", "Create-Post", ex.ToString());
                }

                ViewBag.madm = new SelectList(db.PhongMays, "MaPMT", "TenPMT", thoiKhoaBieu.MaPMT);
                return View(thoiKhoaBieu);
            }

            // GET: Admin/QLDienThoai/Edit/5
            public ActionResult Edit(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieux.Find(id);
                if (thoiKhoaBieu == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDDM = new SelectList(db.PhongMays, "MaPMT", "TenPMT", thoiKhoaBieu.PhongMay);
                return View(    thoiKhoaBieu);
            }

            // POST: Admin/QLDienThoai/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "MaTKB,MaPMT,MaND,HocKy,MonHoc,TenGV,Thu,TuTiet,DenTiet,NgayBD,SoLuongSV")] ThoiKhoaBieu thoiKhoaBieu)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(thoiKhoaBieu).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDDM = new SelectList(db.PhongMays, "MaPMT", "TenPMT", thoiKhoaBieu.MaPMT);
                return View(thoiKhoaBieu);
            }

            // GET: Admin/QLDienThoai/Delete/5
            public ActionResult Delete(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieux.Find(id);
                if (thoiKhoaBieu == null)
                {
                    return HttpNotFound();
                }
                return View(thoiKhoaBieu);
            }

            // POST: Admin/QLDienThoai/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieux.Find(id);
                db.ThoiKhoaBieux.Remove(thoiKhoaBieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        
    }
}