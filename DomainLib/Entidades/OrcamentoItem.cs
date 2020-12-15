namespace DomainLib.Entidades
{
    public class OrcamentoItem
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int Qtde { get; set; }
        public string DescricaoItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public bool Cancelado { get; set; }
        public virtual Orcamento Orcamento { get; set; }
    }
}