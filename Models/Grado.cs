using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Models
{
    public class Grado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string Semestre { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string Estatus { get; set; }

        public ICollection<Alumno>Alumno { get; set; }
    }
}
