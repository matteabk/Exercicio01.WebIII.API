using Microsoft.AspNetCore.Mvc;
using WEB.Aula01.Core.Model;
using WEB.Aula01.Core.Interfaces;
using WEB.Aula01.Filters;

namespace WEB.Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")] //DEFINIR PRODUCES E CONSUMES DO SWAGGER!!
    [Produces("application/json")] //IGUAL EM CIMA
    [TypeFilter(typeof(LogActionFilter))]

    public class CadastroController : ControllerBase
    {

        public IClienteServices _clienteServices;

        public CadastroController(IClienteServices clienteService)
        {
            _clienteServices = clienteService;
        }

        [HttpPost("clientes/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(InvalidarCPFRepetidoActionFilter))]
        public ActionResult<Clientes> Post(Clientes cliente)
        {
            if(!_clienteServices.InsertClient(cliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Post), cliente);
        }

        [HttpGet("/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Clientes>> Get()
        {
            return Ok(_clienteServices.GetClientes());
        }

        [HttpGet("/clientesPorId/{id}")] //FALTA ESSE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Clientes> Get(long id)
        {
            if (_clienteServices.GetById(id) == null)
            {
                return NotFound();
            }
            return Ok(_clienteServices.GetById(id));
        }

        [HttpGet("/clientesPorCpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Clientes> GetByCPF(string cpf)
        {
            if (_clienteServices.GetByCPF(cpf) == null)
            {
                return NotFound();
            }
            return Ok(_clienteServices.GetByCPF(cpf));
        }

        [HttpDelete("Deletar usuário")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(long id)
        {
            if(!_clienteServices.DeleteProduto(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("clientes/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ConferirClienteExistenteActionFilter))]
        public IActionResult Put(long id, Clientes cadastroAtualizado)
        {
            if(!_clienteServices.UpdateProduto(id, cadastroAtualizado))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();

        }
    }
}
