using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/carrinho")]
    public class CarrinhoController : ControllerBase
    {
        private readonly DataContext _context;

        public CarrinhoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Carrinho obj)
        {
            _context.Carrinho.Add(obj);
            _context.SaveChanges();
            return Created("", obj);
        }
    }
}
