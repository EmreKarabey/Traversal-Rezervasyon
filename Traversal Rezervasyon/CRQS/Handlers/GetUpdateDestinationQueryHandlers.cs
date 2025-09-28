using DataAccessLayer.Concrete;
using Traversal_Rezervasyon.CRQS.Commands;
using EntityLayer.Concrete;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetUpdateDestinationQueryHandlers
    {
        private readonly Context _context;

        public GetUpdateDestinationQueryHandlers(Context context)
        {
            _context = context;
        }

        public void Handle(GetUpdateDestinationQueryCommands p)
        {
            var gstr = _context.Destinations.Find(p.DestinationID);

            gstr.DestinationID = p.DestinationID;

            gstr.Capacity = p.Capacity;

            gstr.DayNight = p.DayNight;

            gstr.Price = p.Price;


            _context.Destinations.Update(gstr);

            _context.SaveChanges();
        }
    }
}
