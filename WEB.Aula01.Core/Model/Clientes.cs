using System.ComponentModel.DataAnnotations;

namespace WEB.Aula01.Core.Model
{
    public class Clientes
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Por favor, inserir um CPF de 11 dígitos.")]
        public string Cpf { get; set; } = String.Empty;

        [Required(ErrorMessage = "Por favor, inserir nome.")]
        public string Nome { get; set; } = String.Empty;

        [Required(ErrorMessage = "Por favor, inserir data de nascimento.")]
        public DateTime DataNascimento { get; set; }
        public int Age { get
            {
                int Age = (int)(DateTime.Today - DataNascimento).TotalDays;
                Age = Age / 365;
                return Age;
            } }

    }
}
