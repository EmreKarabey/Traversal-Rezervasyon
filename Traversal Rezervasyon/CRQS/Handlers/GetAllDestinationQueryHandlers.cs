using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Traversal_Rezervasyon.CRQS.Results;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetAllDestinationQueryHandlers
    {
        public List<GetDestinationQueryResults> getAllDestinationQueryResults()
        {
            using var c = new Context();
            var gstr = c.Destinations.Select(n=>new GetDestinationQueryResults
            {
                DestinationID = n.DestinationID,
                City = n.City,
                Capacity = n.Capacity,
                Price = n.Price,
                DayNight = n.DayNight
            }).AsNoTracking().ToList();

            return gstr;
        }

      

    }
}
