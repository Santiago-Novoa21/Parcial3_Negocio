using Microsoft.AspNetCore.Mvc;
using Negocio.API.Data;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/members")]

    public class MembersController:ControllerBase
    {
        private readonly DataContext _context;
        public MembersController(DataContext context)
        {
            
            _context = context;

        }

    }
}
