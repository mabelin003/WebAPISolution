using System.ComponentModel.DataAnnotations;

namespace WebAPISolution.Model
{
    public class Docente
    {
        [Key]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int DocenteId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100)]
        public string Apellidos { get; set; }   
    }
}
