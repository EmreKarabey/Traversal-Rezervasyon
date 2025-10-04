using Microsoft.AspNetCore.SignalR;
using SignalRApiProject.Model;

namespace SignalRApiProject.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly VisitorServicesModel _visitorServicesModel;

        public VisitorHub(VisitorServicesModel visitorServicesModel)
        {
            _visitorServicesModel = visitorServicesModel;
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList",_visitorServicesModel.GetVisitorChartList());
        }

    }
}
