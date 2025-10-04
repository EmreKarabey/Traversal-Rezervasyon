using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiProject.DAL.Entity;
using SignalRApiProject.Model;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorServicesModel _visitorServicesModel;
        public VisitorController(VisitorServicesModel visitorServicesModel)
        {
            _visitorServicesModel = visitorServicesModel;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newvisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100, 2000),
                        VisitDate = DateTime.Now.AddDays(x)
                    };
                    _visitorServicesModel.AddVisitor(newvisitor).Wait();
                    Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçiler Başarılı Bir Şekilde Eklenildi");
        }
    }
}
