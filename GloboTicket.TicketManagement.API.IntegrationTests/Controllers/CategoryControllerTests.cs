using GloboTicket.TicketManagement.Api;
using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Controllers
{
    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
    }
}
