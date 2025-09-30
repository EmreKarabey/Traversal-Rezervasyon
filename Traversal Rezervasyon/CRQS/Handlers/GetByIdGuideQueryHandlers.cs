using DataAccessLayer.Concrete;
using MediatR;
using Traversal_Rezervasyon.CRQS.Queries;
using Traversal_Rezervasyon.CRQS.Results;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetByIdGuideQueryHandlers : IRequestHandler<GetByIdGuideQueryQueries, GetByIdGuideQueryResults>
    {
        private readonly Context _context;

        public GetByIdGuideQueryHandlers(Context context)
        {
            _context = context;
        }
        public async Task<GetByIdGuideQueryResults> Handle(GetByIdGuideQueryQueries request, CancellationToken cancellationToken)
        {
            var gstr = await _context.Guides.FindAsync(request.GuideID);

            return  new GetByIdGuideQueryResults
            {
                Description = gstr.Description,

                Name = gstr.Name,

                GuideID = gstr.GuideID
            }; 
        }
    }
}
