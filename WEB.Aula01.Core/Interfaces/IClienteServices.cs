using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB.Aula01.Core.Model;

namespace WEB.Aula01.Core.Interfaces
{
    public interface IClienteServices
    {
        public List<Clientes> GetClientes();

        public Clientes GetById(long id);

        public Clientes GetByCPF (string cpf);

        public bool InsertClient(Clientes cliente);

        public bool DeleteProduto(long id);

        public bool UpdateProduto(long id, Clientes cliente);
    }
}
