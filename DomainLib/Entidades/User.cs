using DomainLib.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DomainLib.Entidades
{
    [DisplayForClass(Name = "Usuario")]
    public class User : BaseEntity
    {
        /// <summary>
        /// Constante usada para validação de nomes em api
        /// </summary>
        //public const string displayName = "usuario";
        public User()
        {
            DataInclusao = DateTime.Now;
        }

        private readonly Dictionary<int, string> tipoUsuario = new Dictionary<int, string>()
        {
            {1,"Administrador"},
            {2, "Operador"},
            {3,"Visitante"}
        };

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public int IdTipo { get; set; }

        [NotMapped]
        public string NivelAcesso
        {
            get
            {
                var result = tipoUsuario.FirstOrDefault(f => f.Key == IdTipo).Value;
                return result;
            }
        }

        public List<KeyValuePair<int, string>> TipoUsuarioList()
        {
            var resultList = tipoUsuario.ToList();

            return resultList;
        }

        public bool ModelIsValid()
        {
            var validator = new UserValidator();
            var results = validator.Validate(this);
            return results.IsValid;
        }
    }

    [NotMapped]
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Favor informar um nome de usuário");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Favor informar um e-mail válido");
            RuleFor(x => x.Password).NotEmpty().Length(6, 15);
            RuleFor(x => x.PasswordConfirm).NotEmpty();
        }
    }
}