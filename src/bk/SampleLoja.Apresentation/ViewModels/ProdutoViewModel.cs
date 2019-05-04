using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleLoja.Apresentation.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nomeproduto { get; set; }

        [DataType(DataType.Currency)] // Moeda
        [Range(typeof(decimal),"0","999999999999")] // Valor que aceito
        [Required(ErrorMessage = "Preenchar um valor")]
        public decimal Valorproduto { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }

        //O produto está vinculado a meu cliente
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}