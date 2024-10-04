using Microsoft.AspNetCore.Mvc;
using Negocio.API.Data;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/reservations")]

    public class ReservationsController: ControllerBase
    {
        private readonly DataContext _context;
        public ReservationsController(DataContext context)
        {
            
            _context = context;

        }
    }
}
