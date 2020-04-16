using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace projeto_forum.Models
{
    public class RegisterViewModel
    {
        [Required, DisplayName("Nome")]
        public string Name { get; set; }
        [Required, DisplayName("Senha")]
        public string Password { get; set; }
        [Required, DisplayName("Confirme Senha")]
        public string RepeatPassword { get; set; }
        [Required, DisplayName("Descrição")]
        public string Description { get; set; }
        
    }
}