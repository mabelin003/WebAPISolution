using System.ComponentModel.DataAnnotations;

namespace WebAPISolution.Model
{
    public class Asignacion
    {
        [Key]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int AsignacionId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int EstudianteId { get; set;}

        [Required(ErrorMessage = "Campo obligatorio")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int DocenteId { get; set; }

    }
}
