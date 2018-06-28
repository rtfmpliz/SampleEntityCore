using SampleEntityCore.Data;
using SampleEntityCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEntityCore.DAL
{
    public class CategoryDAL : ICategory
    {
        private POSDataContext _context;

        public CategoryDAL(POSDataContext context)
        {
            _context = context;
        }

        public void Create(Category obj)
        {
            try
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public void Delete(string id)
        {
            try
            {
                var result = GetById(id);
                if (result!=null)
                {
                    _context.Categories.Remove(result);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Data tidak ditemukan !");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Edit(string id, Category obj)
        {
            try
            {
                var result = GetById(id); //dicari dulu ada tidak yg mau diedit //OOP
                if (result != null)
                {
                    result.CategoryName = obj.CategoryName; 
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("DAta Tidak Ditemukan !");
            }
        }

        public IEnumerable<Category> GetAll()
        {
            //var results = from c in _context.Categories // typenya IQueryable
            //              orderby c.CategoryName ascending //lebih mudah dipahami daripada lambda dibawah
            //              select c;
            var results = _context.Categories.OrderBy(c => c.CategoryName);
            return results;
        }

        public Category GetById(string id)
        {
            var results = (from c in _context.Categories
                           where c.CategoryID == Convert.ToInt32(id)
                           select c).SingleOrDefault();
            return results;
        }
    }
}
