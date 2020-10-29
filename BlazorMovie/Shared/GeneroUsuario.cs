using System.ComponentModel.DataAnnotations;

namespace BlazorMovie.Shared
{
    public class GeneroUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é requerido.")]
        public string Name { get; set; }
    }
}
