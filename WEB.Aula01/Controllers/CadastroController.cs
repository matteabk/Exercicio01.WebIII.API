using Microsoft.AspNetCore.Mvc;
using WEB.Aula01.Repository;

namespace WEB.Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")] //DEFINIR PRODUCES E CONSUMES DO SWAGGER!!
    [Produces("application/json")] //IGUAL EM CIMA

    public class CadastroController : ControllerBase
    {
        public List<Clientes> Clients { get; set; } = new List<Clientes>();

        public ClientesRepository _repositoryCliente;

        public CadastroController(IConfiguration configuration)
        {
            _repositoryCliente = new ClientesRepository(configuration);
        }

        [HttpPost("clientes/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Clientes> Post(Clientes informacoes)
        {
            if(!_repositoryCliente.InsertClient(informacoes))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Post), informacoes);
        }

        [HttpGet("/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Clientes>> Get()
        {
            return Ok(_repositoryCliente.GetClientes());
        }

        [HttpGet("/clientes/{id}")] //FALTA ESSE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Clientes> Get(long id)
        {
            if (_repositoryCliente.GetByIndex(id) == null)
            {
                return NotFound();
            }
            return Ok(_repositoryCliente.GetByIndex(id));
        }

        [HttpDelete("Deletar usuário")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(long id)
        {
            if(!_repositoryCliente.DeleteProduto(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("clientes/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(long id, Clientes cadastroAtualizado)
        {
            if(!_repositoryCliente.UpdateProduto(id, cadastroAtualizado))
            {
                return BadRequest();
            }
            return NoContent();

        }
    }
}
