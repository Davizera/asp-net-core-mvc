using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.MVC
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            try
            {
                var classe = context.GetRouteValue("classe").ToString();
                var nomeMetodo = context.GetRouteValue("metodo").ToString();
                var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{classe}Logica";

                var tipo = Type.GetType(nomeCompleto);
                var metodo = tipo.GetMethods().Where(metodos => metodos.Name == nomeMetodo).First();
                var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

                return requestDelegate.Invoke(context);

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync($"Erro ao tentar acessar URL!\n{ex.Message}");
            }
        }
    }
}
