using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLib.Entidades
{
    public class Orcamento : BaseEntity
    {
        public int IdCliente { get; set; }
        public int IdOperador { get; set; }
        public string NomeContato { get; set; }
        public string EmailContato { get; set; }
        public string FoneContato { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public decimal ValorSugerido { get; set; }
        public decimal ValorAprovado { get; set; }
        public bool Aprovado { get; set; }
        public DateTime AprovadoEm { get; set; }
        public string AprovadoPor { get; set; }
        public bool Cancelado { get; set; }
        public string Observacao { get; set; }

        [NotMapped]
        public virtual List<OrcamentoItem> Itens { get; set; }

        [NotMapped]
        public virtual Cliente Cliente { get; set; }
    }

    public class OrcamentoValidator : AbstractValidator<Orcamento>
    {
        public OrcamentoValidator()
        {
            RuleFor(x => x.NomeContato).NotEmpty().WithMessage("Favor informar um nome de usuário");
            RuleFor(x => x.EmailContato).NotEmpty().WithMessage("Favor informar um e-mail válido");
            RuleFor(x => x.FoneContato).NotEmpty().Length(6, 15);
            RuleFor(x => x.ValorSugerido).GreaterThan(0);
            RuleFor(x => x.DataValidade).NotEmpty();
            RuleFor(x => x.IdOperador).GreaterThan(0);
            RuleFor(x => x.IdCliente).GreaterThan(0);
        }
    }
}