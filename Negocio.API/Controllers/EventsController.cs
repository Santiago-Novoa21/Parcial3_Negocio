using Microsoft.AspNetCore.Mvc;
using Negocio.API.Data;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/events")]
    public class EventsController:ControllerBase
    {
        private readonly DataContext _context;
        public EventsController(DataContext context)
        {
            
            _context = context;

        }
    }
}
