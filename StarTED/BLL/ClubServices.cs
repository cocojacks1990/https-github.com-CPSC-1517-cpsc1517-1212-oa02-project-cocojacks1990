using StarTEDsystem.DAL;
using StarTEDsystem.Entities;

namespace StarTEDsystem.BLL
{
    public class ClubServices
    {
        private readonly StartedContext _context;
        internal ClubServices(StartedContext context)
        {
            _context = context;
        }

        public List<Club> Club_List(bool active, int pageSize, int pageNumber, out int count)
        {
            var query = _context
              .Clubs
              .Where(x => x.Active == active)
              .OrderBy(x => x.ClubName);
            
            count = query.Count();
            return query
              .Skip((pageNumber - 1)*pageSize)
              .Take(pageSize)
              .ToList();
        }
        
        public Club Club_ByID(int clubid)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context
                .Clubs
                .Where(x => x.ClubID.Equals(clubid))
                .FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        


    }
}
