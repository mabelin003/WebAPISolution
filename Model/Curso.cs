using System.ComponentModel.DataAnnotations;

namespace WebAPISolution.Model
{
    public class Curso
    {
        [Key]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(25)]
        public string Nombre { get; set; }
    }
}
