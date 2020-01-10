using System.Threading.Tasks;
using Demo.Graph;
using GraphQL;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class GraphQlController : ControllerBase
    {
        private IStarWarsSchema Context { get; }

        [HttpGet("{query}")]
        public async Task<IActionResult> Get([FromRoute] string query)
        {
            var response = await Context.ExecuteAsync(queryBuilder => {
                queryBuilder.Query = query;
            });

            if(string.IsNullOrEmpty(response))
                return BadRequest(query);

            return Ok(response);
        }

        public GraphQlController(IStarWarsSchema context)
        {
            Context = context;
        }
    }
}