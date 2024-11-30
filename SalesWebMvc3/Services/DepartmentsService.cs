using SalesWebMvc3.Data;
using SalesWebMvc3.Models;

namespace SalesWebMvc3.Services
{
    public class DepartmentsService
    {

        private readonly SalesWebMvc3Context _context;

        public DepartmentsService(SalesWebMvc3Context context)
        {
            _context = context;
        }
        public List<Departments> FindAll()
        {
            return _context.Departments.OrderBy(x => x.Name).ToList();
        }

    }
}
