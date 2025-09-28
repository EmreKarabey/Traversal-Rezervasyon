namespace Traversal_Rezervasyon.CRQS.Commands
{
    public class GetUpdateDestinationQueryCommands
    {
   

        public int DestinationID { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public string DayNight { get; set; }
        public int Capacity { get; set; }
    }
}
