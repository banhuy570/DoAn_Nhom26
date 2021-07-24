using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using ModelEF.Model;
using PagedList;

namespace TestUngDung.DAO
{
    public class UserDao
    {
        Model1 db = null;
        public UserDao()
        {
            db = new Model1();
        }
        public NguoiDung GetById(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.MaND == userName);
        }
        public string Insert(NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        HttpContext.Current.Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return entity.MaND;
        }


        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.NguoiDungs.SingleOrDefault(x => x.MaND == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.Quyen == "AD")
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.MatKhau == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
            return -3;
        }
        public bool CheckUserName(string userName)
        {
            return db.NguoiDungs.Count(x => x.MaND == userName) > 0;
        }
        public IEnumerable<NguoiDung> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<NguoiDung> model = db.NguoiDungs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaND.Contains(searchString));
            }

            return model.OrderByDescending(x => x.MaND).ToPagedList(page, pageSize);
        }
        //public IEnumerable<Product> ListAllPaging1(string searchString, int page, int pageSize)
        //{
        //    IQueryable<Product> model = db.Products;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Name.Contains(searchString));
        //    }
        //    return model.OrderBy(x => x.UnitCost).OrderByDescending(y => y.Quantity).ToPagedList(page, pageSize);
        //}
    }
}