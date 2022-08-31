using System.ComponentModel.DataAnnotations;

namespace WEB.Aula01
{
    public class Cadastro
    {
        [Required]
        [MaxLength(11, ErrorMessage = "Por favor, inserir um CPF de 11 dígitos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, inserir nome.")]
        public string NamePeople { get; set; }

        [Required(ErrorMessage = "Por favor, inserir data de nascimento.")]
        public DateTime Birthday { get; set; }
        public int Age { get { return DateTime.Now.Year - Birthday.Year; } }

    }
}
