using FluentValidation;
using System;
using System.Collections.Generic;

namespace DomainLib.Entidades
{
    public class OrdemServico : BaseEntity
    {
        public int IdCliente { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrcamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAgendada { get; set; }
        public DateTime DataExecucao { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorDespesa { get; set; }
        public int CondicaoPagamento { get; set; }
        public int TipoPagamento { get; set; }
        public bool Finalizado { get; set; }
        public bool Pago { get; set; }
        public bool Cancelado { get; set; }
        public bool GeraImposto { get; set; }
        public string Observacao { get; set; }
        public virtual List<OrdemServicoItem> ItensDoServico { get; set; }
        public virtual Cliente Cliente { get; set; }
    }

    public class OrdemServicoValidator : AbstractValidator<OrdemServico>
    {
        public OrdemServicoValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Favor informar um nome de usuário");
            RuleFor(x => x.ValorInicial).NotEmpty().WithMessage("Favor informar um e-mail válido");
            RuleFor(x => x.CondicaoPagamento).GreaterThan(0);
            RuleFor(x => x.ItensDoServico.Count).GreaterThan(0);
        }
    }
}