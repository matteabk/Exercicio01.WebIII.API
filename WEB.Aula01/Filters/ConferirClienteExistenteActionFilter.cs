using Microsoft.AspNetCore.Mvc.Filters;
using WEB.Aula01.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Aula01.Filters
{
    public class ConferirClienteExistenteActionFilter : ActionFilterAttribute
    {
        public IClienteServices _clienteServices;
        public ConferirClienteExistenteActionFilter(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long idCliente = (long)context.ActionArguments["id"];

            if (_clienteServices.GetById(idCliente) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
                Console.WriteLine("Não foi encontrado este ID para atualização.");
            }
        }

    }
}
