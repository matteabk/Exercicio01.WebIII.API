using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WEB.Aula01.Filters
{
    public class LogActionFilter : IActionFilter
    {
        Stopwatch stopwatch = new();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}.{1:00} Segundos",
            ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine($"A ação levou {elapsedTime}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
            Console.WriteLine("Iniciando ação..");

        }
    }
}
