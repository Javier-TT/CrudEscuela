using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string Estatus { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [Display(Name ="Fecha de Alta")]
        public DateTime FechadeAlta { get; set; }
        public int GradoId { get; set; }

        public bool Estado { get; set; }

        public bool Eliminado{ get; set; }

    }

}
