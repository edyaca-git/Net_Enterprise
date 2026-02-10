using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetEnterprise.Application.DTOs.User;

public class RegisterUserDto
{
    [Required(ErrorMessage = "El nombre de usuario es requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener entre 3 y 100 caracteres")]
    public string UserAccount { get; set; } = null!;

    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "El email no es válido")]
    [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "El teléfono es requerido")]
    [Phone(ErrorMessage = "El teléfono no es válido")]
    [StringLength(50, ErrorMessage = "El teléfono no puede exceder 50 caracteres")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es requerida")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Debe confirmar la contraseña")]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = "Debe seleccionar un país")]
    public int CountryId { get; set; }

    [Required(ErrorMessage = "Debe aceptar la política de privacidad")]
    public bool PrivacyAccepted { get; set; }

    [Required(ErrorMessage = "Debe seleccionar sucursal")]
    public int BranchId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar role")]
    public string UserRole { get; set; } = null!;

    [JsonIgnore]
    public int UserId { get; set; }
}