using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace projeto_forum.Models
{
    public class RegisterViewModel
    {
        [Required, DisplayName("Digite o seu Nome!")]
        public string Name { get; set; }
        [Required, DisplayName("Digite uma senha!")]
        public string Password { get; set; }
        [Required, DisplayName("confirme sua senha!")]
        public string RepeatPassword { get; set; }
        [Required, DisplayName("As senha devem ser identicas!")]
        public string Description { get; set; }
        
    }
}