using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmpregaSENAI.Models
{
    public class Curriculo 
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Nome completo")]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Telefone { get; set; }

        public string EstadoCivil { get; set; }

        [Required]
        public string Email { get; set; }

        public string Experiencia { get; set; }

        public string Formacao { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

    }
}
