using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/formasdepagamento")]
    public class FormasDePagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        
        public FormasDePagamentoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FormasDePagamento obj)
        {
            _context.FormasDePagamento.Add(obj);
            _context.SaveChanges();
            return Created("", obj);
        }
    }
}
