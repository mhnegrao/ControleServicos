using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLib.Entidades
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        [NotMapped]
        public string Uri { get; set; }
    }
}