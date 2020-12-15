using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLib.Entidades
{
    public class ItemCompra : BaseEntity
    {
        public string DescricaoItem { get; set; }
        public int Qtde { get; set; }
        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return ValorUnitario * Qtde;
            }
        }
        public bool Comprado { get; set; }
        public bool ManterLista { get; set; }
        public bool Cancelado { get; set; }
    }
}
