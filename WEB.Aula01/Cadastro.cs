namespace WEB.Aula01
{
    public class Cadastro
    {
        public string Cpf { get; set; }
        public string NamePeople { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get { return DateTime.Now.Year - Birthday.Year; } }

    }
}
