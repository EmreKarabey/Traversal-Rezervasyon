using DocumentFormat.OpenXml.Wordprocessing;

namespace Traversal_Rezervasyon.CRQS.Results
{
    public class GetAllDestinationQueryResults
    {
        public int id { get; set; }
        public string city { get; set; }
        public string Daynight { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
