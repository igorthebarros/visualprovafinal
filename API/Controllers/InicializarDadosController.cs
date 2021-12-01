using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Periférico" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Headset", Preco = 300, Quantidade = 2, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Teclado", Preco = 200, Quantidade = 3, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Mouse", Preco = 200, Quantidade = 4, CategoriaId = 1 },
                }
            );
            _context.FormasDePagamento.AddRange(new FormasDePagamento[]
                {
                    new FormasDePagamento { Id = 1, Nome = "Pix", ImprimirComprovante = false, CriadoEm = DateTime.UtcNow },
                    new FormasDePagamento { Id = 2, Nome = "Crédito", ImprimirComprovante = true, CriadoEm = DateTime.UtcNow },
                    new FormasDePagamento { Id = 3, Nome = "Débito", ImprimirComprovante = true, CriadoEm = DateTime.UtcNow },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}