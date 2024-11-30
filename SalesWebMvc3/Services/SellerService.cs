using SalesWebMvc3.Data;
using SalesWebMvc3.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc3.Services.Exeptions;
namespace SalesWebMvc3.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc3Context _context;

        public SellerService(SalesWebMvc3Context context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }
        public void Insert(Seller obj)
        {
            obj.Departments = _context.Departments.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Sellers.Include(obj => obj.Departments).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if(!_context.Sellers.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundExeption("id not found...");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
