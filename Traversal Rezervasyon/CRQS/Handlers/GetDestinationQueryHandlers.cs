
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Traversal_Rezervasyon.CRQS.Queries;
using Traversal_Rezervasyon.CRQS.Results;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetDestinationQueryHandlers
    {
        private readonly Context _context;


        public GetDestinationQueryHandlers(Context context)
        {
            _context = context;
        }
        public GetDestinationQueryResults Handle(GetDestinationQueryQueries id)
        {
            var gstr = _context.Destinations.Find(id.id);

            GetDestinationQueryResults p = new GetDestinationQueryResults()
            {
                City = gstr.City,
                Capacity = gstr.Capacity,
                DayNight = gstr.DayNight,
                DestinationID = gstr.DestinationID,
                Price = gstr.Price

            };

            return p;

            


        }
    }
}
