
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

            return new GetDestinationQueryResults
            {
                DestinationID = gstr.DestinationID,
                Capacity = gstr.Capacity,
                City = gstr.City,
                DayNight = gstr.DayNight,
                Price = gstr.Price
            };


        }
    }
}
