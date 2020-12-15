using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLib.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }

        [NotMapped]
        public List<Produto> Produtos { get; set; }

        public decimal ValorPedido { get; set; }
        public int QtdeItens { get; set; }
        public bool Finalizado { get; set; }
        public bool Pago { get; set; }
        public int TipoPagto { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}