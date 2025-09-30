using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Traversal_Rezervasyon.CRQS.Queries;
using Traversal_Rezervasyon.CRQS.Results;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetAllGuideQueryHandlers:IRequestHandler<GetAllGuideQueryQueries,List<GetAllGuideQueryResults>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandlers(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResults>> Handle(GetAllGuideQueryQueries request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(N => new GetAllGuideQueryResults
            {
                GuideID = N.GuideID,

                Name = N.Name,


                Description = N.Description
            }).AsNoTracking().ToListAsync();
        }

    }
}
