using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorMovie.Shared.Model
{
    public class RegisterModel
    {
        [Key]
        public int Key { get; set; }

        [Required(ErrorMessage = "O campo Title é requerido.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo First Name é requerido.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo Last Name é requerido.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo Data Birth é requerido.")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma Data válida.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "O campo E-mail é requerido.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é requerido.")]
        [MinLength(6, ErrorMessage = "Informe um Password com no mínimo 6 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirm Password é requerido.")]
        [Compare("Password", ErrorMessage = "A Password e o Confirm Password senha devem ser iguais.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O campo Accept Terms é requerido.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "O campo Accept Terms precisa ser aceito.")]
        public bool AcceptTerms { get; set; }
    }
}
