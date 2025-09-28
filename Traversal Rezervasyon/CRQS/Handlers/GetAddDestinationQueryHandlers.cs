using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Traversal_Rezervasyon.CRQS.Commands;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetAddDestinationQueryHandlers
    {
        private readonly Context _context;

        public GetAddDestinationQueryHandlers(Context context)
        {
            _context = context;
        }

        public void AddHandle(GetAddDestinationQueryCommand p)
        {
            _context.Add(new Destination
            {
                City = p.City,
                DayNight = p.DayNight,
                Price = p.Price,
                Capacity = p.Capacity
            });

            _context.SaveChanges();
        }
    }
}
