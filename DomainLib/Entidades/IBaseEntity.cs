using System;

namespace DomainLib.Entidades
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime DataInclusao { get; set; }
        DateTime DataAlteracao { get; set; }
        bool Ativo { get; set; }
    }
}