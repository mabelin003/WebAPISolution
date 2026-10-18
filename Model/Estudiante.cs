using System.ComponentModel.DataAnnotations;

namespace WebAPISolution.Model
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100)]
        public string Direccion { get; set; }   

    }
}
