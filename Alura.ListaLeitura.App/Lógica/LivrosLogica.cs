using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {
        public static string RenderizaListaDinamica(string html, IEnumerable<Livro> livros)
        {
            foreach (var livro in livros)
            {
                html = html.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            html = html.Replace("#NOVO-ITEM#", "");

            return html;
        }

        public string Detalhes(int id)
        {
            try
            {
                int idLivro = id;
                var repo = new LivroRepositorioCSV();
                Livro livro = repo.Todos.First(liv => liv.Id == idLivro);

                return livro.Detalhes();
            }
            catch (Exception ex)
            {
                return $"{ex.Message}\nErro ao tentar mostrar detalhes do livros";
            }
        }

        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = HtmlUtils.CarregaHTML("para-ler");
            html = RenderizaListaDinamica(html, _repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = HtmlUtils.CarregaHTML("lendo");
            html = RenderizaListaDinamica(html, _repo.Lendo.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = HtmlUtils.CarregaHTML("lidos");
            html = RenderizaListaDinamica(html, _repo.Lidos.Livros);
            return context.Response.WriteAsync(html);
        }

        public string Teste()
        {
            return "Tô testando aqui!";
        }
    }
}
