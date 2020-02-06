using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {
            try
            {
                var _repo = new LivroRepositorioCSV();
                _repo.Incluir(livro);

                return "Novo livro cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                return $"Erro ao tentar inclui livro!\n{ex.Message}";
            }
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            try
            {
                var html = HtmlUtils.CarregaHTML("cadastra-livro");
                return context.Response.WriteAsync(html);
            }
            catch (Exception ex)
            {
                return context.Response.WriteAsync($"Não foi possível renderizar o formulário!\n{ex.Message}");
            }
        }
    }
}
