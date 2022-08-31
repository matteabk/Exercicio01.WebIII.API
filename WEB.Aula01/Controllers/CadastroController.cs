using Microsoft.AspNetCore.Mvc;

namespace WEB.Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")] //DEFINIR PRODUCES E CONSUMES DO SWAGGER!!
    [Produces("application/json")] //IGUAL EM CIMA

    public class CadastroController : ControllerBase
    {
        private static readonly string[] Nomes = new[]
        {
        "Matheus", "João", "José", "André", "Maria Luiza", "Louise", "Carlos", "Leonardo", "Antônio", "Ricardo" };

        private static readonly string[] Cpfs = new[]
{
        "13373949475", "62395807087", "80781.45090", "20081908032", "05732398007", "12780279044" };

        public List<Cadastro> Cadastros { get; set; } = new List<Cadastro>();

        public CadastroController()
        {
            Cadastros = Enumerable.Range(1,5).Select(index => new Cadastro
            {
                Cpf = Cpfs[Random.Shared.Next(Cpfs.Length)], //CPFRANDOM
                NamePeople = Nomes[Random.Shared.Next(Nomes.Length)],
                Birthday = Services.RandomDay(),
            }
            ).ToList();
        }

        [HttpPost("clientes/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> Post(Cadastro informacoes)
        {
            Cadastros.Add(informacoes);
            return StatusCode(201, informacoes);
        }

        [HttpGet("/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cadastro>> Get()
        {
            return Ok(Cadastros);
        }

        [HttpGet("/cadastro/{index}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cadastro>> Get(int index)
        {
            if (index >= Cadastros.Count || index < 0)
            {
                return NotFound();
            }
            return Ok(Cadastros[index]);
        }

        [HttpDelete("Deletar usuário")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(string cpf)
        {
            var cadastroSelecionado = Cadastros.RemoveAll(x => x.Cpf == cpf);
            if(cadastroSelecionado == 0)
            {
                return NotFound();
            }
            return NoContent();   
        }

        [HttpPut("clientes/{cpf}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(string cpf, Cadastro cadastroAtualizado)
        {
            var cadastroSelecionado = Cadastros.FindIndex(x => x.Cpf == cpf);
            if(cadastroSelecionado == -1)
            {
                return NotFound();
            }
            Cadastros[cadastroSelecionado] = cadastroAtualizado;
            return NoContent();
        }
    }
}
