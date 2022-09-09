using Microsoft.AspNetCore.Mvc.Filters;
using WEB.Aula01.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using WEB.Aula01.Core.Model;

namespace WEB.Aula01.Filters
{
    public class InvalidarCPFRepetidoActionFilter : ActionFilterAttribute
    {
        public IClienteServices _clienteServices;
        public InvalidarCPFRepetidoActionFilter(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var teste = context.ActionArguments["cliente"] as Clientes;


            if (_clienteServices.GetByCPF(teste.Cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
                Console.WriteLine("Já existe um cadastro de cliente com este Cpf.");
            }
        }
    }
}
