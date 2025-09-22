using APILista02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace APILista02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {

        [HttpPost("cadastrar")]
        public IActionResult CadastrarProduto([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Os dados do produto são obrigatórios.");

            if (string.IsNullOrWhiteSpace(produto.Descricao))
                return BadRequest("A descrição é obrigatória.");

            if (produto.Preco <= 0)
                return BadRequest("O preço deve ser maior que zero.");

            if (produto.Estoque < 0)
                return BadRequest("O estoque não pode ser negativo.");

            if (string.IsNullOrWhiteSpace(produto.CodigoProduto))
                return BadRequest("O código do produto é obrigatório.");

            string padrao = @"^[A-Z]{3}-\d{4}$";

            if (!Regex.IsMatch(produto.CodigoProduto, padrao))
                return BadRequest("O código do produto deve estar no formato AAA-1234.");

            return Ok(new { Mensagem = "Produto cadastrado com sucesso!", Produto = produto });
        }

    }
}
