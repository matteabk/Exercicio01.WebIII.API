using Dapper;
using Microsoft.Data.SqlClient;

namespace WEB.Aula01.Repository
{
    public class ClientesRepository
    {
        private readonly IConfiguration _configuration;

        public ClientesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Clientes> GetClientes()
        {
            var query = "SELECT * FROM Clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Clientes>(query).ToList();
        }

        public Clientes GetByIndex(long id)
        {
            var query = "SELECT * FROM Clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QuerySingleOrDefault<Clientes>(query, parameters);
        }

        public bool InsertClient(Clientes cliente)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @age)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cliente.Cpf);
            parameters.Add("nome", cliente.Nome);
            parameters.Add("dataNascimento", cliente.DataNascimento);
            parameters.Add("age", cliente.Age);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteProduto(long id)
        {
            var query = "DELETE FROM Clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateProduto(long id, Clientes cliente)
        {
            var query = "UPDATE Clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cliente.Cpf);
            parameters.Add("nome", cliente.Nome);
            parameters.Add("dataNascimento", cliente.DataNascimento);
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

    }
}
