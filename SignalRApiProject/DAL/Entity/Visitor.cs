namespace SignalRApiProject.DAL.Entity
{
    public enum ECity
    {
        Balıkesir=1,
        İstanbul=2,
        Samsun=3,
        Rize=4
    }
    public class Visitor
    {
        
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
