using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace projeto_forum.Models
{
    public class LogInViewModel
    {

        [Required, DisplayName("Digite seu Usuário!")]
        public string Name { get; set; }

        [Required, DisplayName("Digite sua Senha!")]
        public string Password { get; set; }
    }
}