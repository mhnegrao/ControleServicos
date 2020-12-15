using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DomainLib.Entidades
{
    public class Endereco
    {
        private readonly Dictionary<int, string> tipoEndereco = new Dictionary<int, string>()
        {
            {1,"Residencial"},
            {2, "Comercial"},
            {3,"Provisório"}
        };

        public int Id { get; set; }
        public int IdTipo { get; set; }
        public int IdCliente { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [NotMapped]
        public string EnderecoCompleto
        {
            get
            {
                var endereco = $"{Logradouro.Trim()}, {Numero.Trim()}, {Bairro.Trim()}/{Municipio.Trim()} - CEP: {Cep}";
                return endereco;
            }
        }

        [NotMapped]
        public string Localidade { get; set; }

        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }

        [NotMapped]
        public string Gps { get; set; }

        [NotMapped]
        public string IBGE { get; set; }

        [NotMapped]
        public string GIA { get; set; }

        [NotMapped]
        public string TipoEndereco
        {
            get
            {
                var result = tipoEndereco.FirstOrDefault(f => f.Key == IdTipo).Value;
                return result;
            }
        }

        public virtual ICollection<Cliente> Cliente { get; set; }
        /*

             public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }*/

        public List<KeyValuePair<int, string>> TipoEnderecoList()
        {
            var resultList = tipoEndereco.ToList();

            return resultList;
        }
    }
}