using StarTEDsystem.DAL;
using StarTEDsystem.Entities;

namespace StarTEDsystem.BLL
{
    public class EmployeeServices
    {
        private readonly StartedContext _context;
        internal EmployeeServices(StartedContext context)
        {
            _context = context;
        }
        public List<Employee> employee_List()
        {
            return _context
             .Employees
             .Where(x => x.Clubs.Any(y => x.EmployeeID == y.EmployeeID))
             .OrderBy(x => x.LastName)
             .ToList();
        }

        public List<Employee> employee_byID()
        {
            return _context
            .Employees
            .Where(item => item.PositionID == 3 || item.PositionID == 4 || item.PositionID == 5)
            .OrderBy(item => item.LastName)
            .ToList();
      
        }

    }
}
