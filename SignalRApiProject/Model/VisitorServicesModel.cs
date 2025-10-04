using System.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using SignalRApiProject.DAL.Concrete;
using SignalRApiProject.DAL.Entity;
using SignalRApiProject.Hubs;

namespace SignalRApiProject.Model
{
    public class VisitorServicesModel
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorServicesModel(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;

            _hubContext = hubContext;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task AddVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitList", GetVisitorChartList());
        }

        public List<VisitorChartModel> GetVisitorChartList()
        {
            List<VisitorChartModel> visitorChartModels = new List<VisitorChartModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select tarih,[1],[2],[3],[4] from(Select [City],CityVisitCount,cast([VisitDate] as Date )as tarih from Visitors) as visittables pivot(Sum(CityVisitCount) for City in ([1],[2],[3],[4])) as pivottable order by tarih asc";
                command.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChartModel visitorChartModel = new VisitorChartModel();

                        visitorChartModel.VisitDateTime = reader.GetDateTime(0);

                        Enumerable.Range(1, 4).ToList().ForEach(n =>
                        {
                            visitorChartModel.Visitcount.Add(reader.GetInt32(n));

                        });
                        visitorChartModels.Add(visitorChartModel);
                    }
                }
                _context.Database.CloseConnection();
                return visitorChartModels;
            }
        }

    }
}
