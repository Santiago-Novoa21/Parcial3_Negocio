using Microsoft.AspNetCore.Mvc;
using Negocio.API.Data;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/workspaces")]

    public class WorkspacesController:ControllerBase
    {
        private readonly DataContext _context;
        public WorkspacesController(DataContext context)
        {
            _context = context;
            
        }


    }
}
