using System.Collections.Generic;

namespace DomainLib.Entidades
{
    public class Documento
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public int IdCliente { get; set; }
        public string Numero { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}