using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DomainLib.Entidades
{
    public class Cliente : BaseEntity
    {
        private readonly Dictionary<int, string> tipoCliente = new Dictionary<int, string>()
        {
            {1,"Pessoa Física"},
            {2, "Pessoa Jurídica"},
            {3,"Outros"}
        };

        #region ...propriedades...
        public int Tipo { get; set; }

        [NotMapped]
        public string TipoCliente
        {
            get
            {
                var result = tipoCliente.FirstOrDefault(f => f.Key == Tipo).Value;
                return result;
            }
        }

        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [NotMapped]
        public string ConfirmaSenha { get; set; }

        [NotMapped]
        public virtual List<Endereco> Enderecos { get; set; } = new List<Endereco>();

        [NotMapped]
        public virtual List<Documento> Documentos { get; set; } = new List<Documento>();

        [NotMapped]
        public virtual List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        [NotMapped]
        public virtual List<OrdemServico> Servicos { get; set; } = new List<OrdemServico>();

        [NotMapped]
        public virtual List<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();

        public string Observacao { get; set; }
        #endregion ...propriedades...

        #region...métodos...

        public List<KeyValuePair<int, string>> TipoClienteList()
        {
            var resultList = tipoCliente.ToList();

            return resultList;
        }

        #endregion
    }

    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Favor informar um nome de usuário");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Favor informar um e-mail válido");
            RuleFor(x => x.Celular).NotEmpty().Length(18);
            RuleFor(x => x.Senha).NotEmpty().Length(6, 15);
            RuleFor(x => x.ConfirmaSenha).NotEmpty().Equal(x => x.Senha);
            RuleFor(x => x.Tipo).GreaterThan(0);
        }
    }
}