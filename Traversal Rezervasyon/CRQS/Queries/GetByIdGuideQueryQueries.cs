using MediatR;
using Traversal_Rezervasyon.CRQS.Results;

namespace Traversal_Rezervasyon.CRQS.Queries
{
    public class GetByIdGuideQueryQueries : IRequest<GetByIdGuideQueryResults>
    {
        public GetByIdGuideQueryQueries(int guideID)
        {
            GuideID = guideID;
        }

        public int GuideID { get; set; }
    }
}
