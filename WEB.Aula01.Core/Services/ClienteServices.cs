using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB.Aula01.Core.Interfaces;
using WEB.Aula01.Core.Model;

namespace WEB.Aula01.Core.Services
{
    public class ClienteServices : IClienteServices
    {
        public IClientesRepository _clientesRepository;
        public ClienteServices(IClientesRepository clienteRepositoyry)
        {
            _clientesRepository = clienteRepositoyry;
        }

        public List<Clientes> GetClientes()
        {
            return _clientesRepository.GetClientes();
        }

        public Clientes GetById(long id)
        {
            return _clientesRepository.GetById(id);
        }

        public Clientes GetByCPF (string cpf)
        {
            return _clientesRepository.GetByCPF(cpf);
        }

        public bool InsertClient(Clientes cliente)
        {
            return _clientesRepository.InsertClient(cliente);
        }

        public bool DeleteProduto(long id)
        {
            return _clientesRepository.DeleteProduto(id);
        }

        public bool UpdateProduto(long id, Clientes cliente)
        {
            return _clientesRepository.UpdateProduto(id, cliente);
        }
    }
}
