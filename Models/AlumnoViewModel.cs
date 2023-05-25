using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Models
{
    public class AlumnoViewModel
    {
        public int IdAlumno { get; set; }

        public string NombreAlumno { get; set; }

        public string ApellidosAlumno { get; set; }

        public string EstatusAlumno { get; set; }

        public DateTime FechadeAltaAlumno { get; set; }

        public bool EstadoAlumno { get; set; }

        public string SemestreGrado { get; set; }

        public string ApellidoAlumno { get; set; }

        public bool EliminadoAlumno { get; set; }
    }
}
