using FluentValidation;

namespace DomainLib.Entidades
{
    public class OrdemServicoItem : BaseEntity
    {
        public int IdServico { get; set; }
        public int IdNatureza { get; set; }
        public int Qtde { get; set; }
        public string DescricaoItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public bool GeraDespesaTerceiros { get; set; }
        public bool Cancelado { get; set; }
        public string Observacao { get; set; }
        public virtual OrdemServico OrdemServico { get; set; }
    }

    public class OrdemServicoItemValidator : AbstractValidator<OrdemServicoItem>
    {
        public OrdemServicoItemValidator()
        {
            RuleFor(x => x.DescricaoItem).NotEmpty().WithMessage("Favor informar um nome de usuário");
            RuleFor(x => x.IdNatureza).GreaterThan(0);
            RuleFor(x => x.ValorUnitario).GreaterThan(0);
            RuleFor(x => x.Qtde).GreaterThan(0);
            RuleFor(x => x.IdServico).GreaterThan(0);
        }
    }
}