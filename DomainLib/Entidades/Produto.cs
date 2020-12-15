using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DomainLib.Entidades
{
    public class Produto
    {
        private readonly Dictionary<int, string> tipoUnidade = new Dictionary<int, string>()
        {
            {1,"Peça"},
            {2,"Pacote"},
            {3, "Kg"},
            {4,"Gramas"},
            {5,"Litro"},
            {6,"Metro" }
        };

        private readonly Dictionary<int, string> tipoCategoria = new Dictionary<int, string>()
        {
            {1,"Outros"},
            {2,"Velas"},
            {3, "Defumadores"},
            {4,"Incensos"},
            {5,"Banhos"},
            {6,"Ceramicas" }
        };

        public int Id { get; set; }
        public int IdCategoria { get; set; }

        public string Codigo { get; set; }
        public int Unidade { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public bool EmEstoque { get; set; }
        public string Observacao { get; set; }

        [NotMapped]
        public string TipoUnidade
        {
            get
            {
                var result = tipoUnidade.FirstOrDefault(f => f.Key == Unidade).Value;
                return result;
            }
        }

        [NotMapped]
        public string TipoCategoria
        {
            get
            {
                var result = tipoCategoria.FirstOrDefault(f => f.Key == IdCategoria).Value;
                return result;
            }
        }

        public List<KeyValuePair<int, string>> TipoUnidadeList()
        {
            var resultList = tipoUnidade.ToList();

            return resultList;
        }

        public List<KeyValuePair<int, string>> TipoCategoriaList()
        {
            var resultList = tipoCategoria.ToList();

            return resultList;
        }
    }
}