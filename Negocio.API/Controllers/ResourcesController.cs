using Microsoft.AspNetCore.Mvc;
using Negocio.API.Data;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/resources")]

    public class ResourcesController:ControllerBase
    {
        private readonly DataContext _context;
        public ResourcesController(DataContext context)
        {
            
            _context = context;

        }

    }
}
