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

        private static readonly string[] Cpfs = new[]
{
        "13373949475", "62395807087", "80781.45090", "20081908032", "05732398007", "12780279044" };

        public List<Cadastro> Cadastros { get; set; } = new List<Cadastro>();

        public CadastroController()
        {
            Cadastros = Enumerable.Range(1,5).Select(index => new Cadastro
            {
                Cpf = Cpfs[index - 1], //CPFRANDOM
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
