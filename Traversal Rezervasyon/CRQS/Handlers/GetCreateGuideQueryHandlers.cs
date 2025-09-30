using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using Traversal_Rezervasyon.CRQS.Commands;

namespace Traversal_Rezervasyon.CRQS.Handlers
{
    public class GetCreateGuideQueryHandlers : IRequestHandler<GetCreateGuideQueryCommand>
    {
        private readonly Context _context;

        public GetCreateGuideQueryHandlers(Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(GetCreateGuideQueryCommand request, CancellationToken cancellationToken)
        {
          await  _context.Guides.AddAsync(new Guide
            {
                Name = request.Name,

                Description = request.Description
            });

           await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
