using Microsoft.AspNetCore.Mvc;

namespace WEB.Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CadastroController : ControllerBase
    {
        private static readonly string[] Nomes = new[]
        {
        "Matheus", "João", "José", "André", "Maria Luiza", "Louise", "Carlos", "Leonardo", "Antônio", "Ricardo" };

        public List<Cadastro> Cadastros { get; set; } = new List<Cadastro>();

        public CadastroController()
        {
            Cadastros = Enumerable.Range(1,6).Select(index => new Cadastro
            {
                Cpf = Services.GerarCpf(), //CPFRANDOM
                NamePeople = Nomes[Random.Shared.Next(Nomes.Length)],
                Birthday = Services.RandomDay(),
            }
            ).ToList();
        }

        [HttpPost("Adicionar pessoas")]
        public Cadastro Post(Cadastro informacoes)
        {
            Cadastros.Add(informacoes);
            return informacoes;
        }

        [HttpGet("Consultar lista")]
        public List<Cadastro> Get()
        {
            return Cadastros;
        }

        [HttpDelete("Deletar usuário")]
        public void Delete(string cpf)
        {
            var cadastroSelecionado = Cadastros.RemoveAll(x => x.Cpf == cpf);
        }

        [HttpPut("Atualizar cadastro")]
        public Cadastro Put(string cpf, Cadastro cadastroAtualizado)
        {
            var cadastroSelecionado = Cadastros.FindIndex(x => x.Cpf == cpf);
            Cadastros[cadastroSelecionado] = cadastroAtualizado;
            return Cadastros[cadastroSelecionado];
        }
    }
}
