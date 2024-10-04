using Microsoft.AspNetCore.Mvc;
using Negocio.API.Data;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/memberships")]

    public class MembershipsController: ControllerBase
    {
        private readonly DataContext _context;
        public MembershipsController(DataContext context)
        {

            _context = context;
            
        }
    }
}
