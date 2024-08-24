using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet.App.Entities.PgSQL
{
    [Table("Matriz")]
    public class Matriz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Nome { get; set; } //private só altera dentro da classe

        [Required]
        [MaxLength(100)]
        public String? Cor { get; set; } //private só altera dentro da classe

        [Required]
        public DateTime DataNascimento { get; set; } //private só altera dentro da classe

        public bool Ativo { get; set; } //private só altera dentro da classe


        public Matriz() { } // Construtor padrão

        public Matriz(string nome, string cor, DateTime dataNascimento)
        {
            Nome = nome; 
            Cor = cor;
            DataNascimento = dataNascimento; 
            Ativo = true;
        }
    }
}
