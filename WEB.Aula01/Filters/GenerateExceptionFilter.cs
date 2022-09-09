using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace WEB.Aula01.Filters
{
    public class GenerateExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails()
            {
                Status = 500,
                Title = "Erro inesperado",
                Detail = "Ocorreu um erro inesperado na solitação",
                Type = context.Exception.GetType().Name
            };

            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}");

            switch(context.Exception)
            {
                case SqlException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    problem.Title = "Erro inesperado, falha ao se contatar com o banco de dados";
                    problem.Detail = "Falha ao se contatar com banco de dados.";
                    problem.Type = context.Exception.GetType().Name;
                    context.Result = new ObjectResult(problem);
                    break;

                case NullReferenceException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    problem.Title = "Erro inesperado no sistema, possível nulo";
                    problem.Detail = "Possível campos nulos";
                    problem.Type = context.Exception.GetType().Name;
                    context.Result = new ObjectResult(problem);
                    break;

                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    problem.Title = "Erro inesperado. Tente novamente";
                    problem.Detail = "Erro inesperado. Tente novamente";
                    problem.Type = context.Exception.GetType().Name;
                    context.Result = new ObjectResult(problem);
                    break;
            }

            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}");
        }
    }
}
