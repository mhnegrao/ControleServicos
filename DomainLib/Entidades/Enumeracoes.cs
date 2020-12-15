using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DomainLib.Entidades
{
    public enum TipoCliente
    {
        [Description("Pessoa Física")]
        PessoaFisica = 1,

        [Description("Pessoa Jurídica")]
        PessoaJuridica
    }

    public enum TipoLancto
    {
        [Description("Débito")]
        Debito = 1,

        [Description("Crédito")]
        Credito,

        Estorno
    }

    public enum TipoEndereco
    {
        Residencial,
        Comercial
    }

    public enum TipoPagamento
    {
        [Description("Cartão de Débito")]
        CartaoDebito = 1,

        [Description("Cartão de Crédito")]
        CartaoCredito,

        Cheque,
        Dinheiro,

        [Description("Transfaerência Bancária")]
        Transferencia
    }

    public enum CondicaoPagamento
    {
        [Description("A Vista")]
        AVista = 1,

        Parcelado
    }

    public class EnumModel
    {
        public EnumModel()
        {
        }

        public int Value { get; set; }
        public string Name { get; set; }
    }

    public interface IConvertEnum<T> where T : Enum
    {
        List<EnumModel> GetList();
    }

    public class ConvertEnum<T> : IConvertEnum<T> where T : Enum
    {
        public ConvertEnum()
        {
        }

        public List<EnumModel> GetList()
        {
            var enums = ((T[])Enum.GetValues(typeof(T)))
                .Select(c => new EnumModel()
                {
                    Value = (int)Convert.ChangeType(c, typeof(int)),
                    Name = c.ToString()
                }).ToList();
            //var values = Enum.GetValues(typeof(T))
            //    .Cast<T>()
            //    .ToDictionary(Descricao =>Descricao.ToString(),Valor =>(int)(Valor))
            //    .ToList();
            return enums.ToList();
        }
    }
}