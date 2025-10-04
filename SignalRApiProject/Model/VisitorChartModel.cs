namespace SignalRApiProject.Model
{
    public class VisitorChartModel
    {
        public VisitorChartModel()
        {
            Visitcount = new List<int>();
        }
        public DateTime VisitDateTime { get; set; }
        public List<int> Visitcount { get; set; }
    }
}
