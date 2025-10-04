namespace SignalRApi.DAL.Entity
{
    public enum ECity
    {
        Balıkesir = 1,
        Ankara = 2,
        İstanbul = 3,
        Bursa = 4,
    }
    public class Visitor
    {
      public int VisitorID { get; set; } 
      public ECity City { get; set; } 
      public int CityVisitCount { get; set; } 
      public DateTime VisitDate { get; set; } 


    }
}
