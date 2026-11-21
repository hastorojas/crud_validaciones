using System.ComponentModel.DataAnnotations;

namespace CRUD_Clientes.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [StringLength(20)]
        [Display(Name = "Tipo de documento")]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento es obligatorio")]
        [RegularExpression(@"^[A-Za-z0-9]{8,12}$", ErrorMessage = "El documento debe tener entre 8 y 12 caracteres alfanuméricos")]
        [Display(Name = "Documento")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El celular es obligatorio")]
        [RegularExpression(@"^9\d{8}$", ErrorMessage = "El celular debe tener 9 dígitos y empezar con 9")]
        [Display(Name = "Celular")]
        public string Celular { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = string.Empty;
    }
}
