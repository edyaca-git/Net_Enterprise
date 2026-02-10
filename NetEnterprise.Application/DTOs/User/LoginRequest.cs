using System.ComponentModel.DataAnnotations;

namespace NetEnterprise.Application.DTOs.User;

public class LoginRequest
{
    [Required(ErrorMessage = "El nombre de usuario es requerido")]
    public string UserAccount { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es requerida")]
    public string Password { get; set; } = null!;
}