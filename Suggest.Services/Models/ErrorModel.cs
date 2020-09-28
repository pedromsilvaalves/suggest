using System.Collections.Generic;

namespace Suggest.Services.Models
{
    public class ErrorModel
    {
        public List<string> Erros { get; } = new List<string>();

        public ErrorModel(string erro)
        {
            Erros.Add(erro);
        }

        public ErrorModel(IEnumerable<string> erros)
        {
            Erros.AddRange(erros);
        }
    }
}
