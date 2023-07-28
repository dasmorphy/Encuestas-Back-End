using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/rol")]
    public class RolController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RolController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var roles = await context.Roles.ToListAsync();
            return Ok(roles);
        }
    }
}
