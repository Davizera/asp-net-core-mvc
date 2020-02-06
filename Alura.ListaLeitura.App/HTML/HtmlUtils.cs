using System.IO;

namespace Alura.ListaLeitura.App.HTML
{
    class HtmlUtils
    {
        public static string CarregaHTML(string nomeDoArquivo)
        {
            var caminhoCompleto = $"../../../HTML/{nomeDoArquivo}.html";
            using (var arquivo = File.OpenText(caminhoCompleto))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
