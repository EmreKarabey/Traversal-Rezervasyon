using MediatR;

namespace Traversal_Rezervasyon.CRQS.Commands
{
    public class GetCreateGuideQueryCommand:IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
