using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using Traversal_Rezervasyon.CRQS.Commands;
using EntityLayer.Concrete;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetDeleteDestinationQueryHandlers
    {
        private readonly Context _context;

        public GetDeleteDestinationQueryHandlers(Context context)
        {
            _context = context;
        }

        public void Handle(GetDeleteDestinationQueryCommands p)
        {
            _context.Destinations.Remove(new Destination
            {
                DestinationID = p.id
            });

            _context.SaveChanges();
        }
    }
}
