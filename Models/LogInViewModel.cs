using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace projeto_forum.Models
{
    public class LogInViewModel
    {

        [Required, DisplayName("Digite seu Usário!")]
        public string Name { get; set; }

        [Required, DisplayName("Digite sua senha!")]
        public string Password { get; set; }
    }
}