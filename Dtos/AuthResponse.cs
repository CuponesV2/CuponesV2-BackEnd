/* Nos ayuda a utilizar unicamente los campos que queremos comparar en el login */
namespace Cupones.Dtos
{
    public class AuthResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}