using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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


        public virtual ICollection<Ninhada> Ninhadas { get; set; }

        public Matriz() { } // Construtor padrão

        public Matriz(string nome, string cor, DateTime dataNascimento)
        {
            Nome = nome;
            Cor = cor;
            DataNascimento = dataNascimento;
            Ativo = true;
        }
    }

    [Table("Ninhada")]
    public class Ninhada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Nome { get; set; } //private só altera dentro da classe

        [Required]
        [MaxLength(100)]
        public int Quantidade { get; set; } //private só altera dentro da classe
        [Required]
        public DateTime DataNascimento { get; set; } //private só altera dentro da classe

        [Required]
        public int MatrizId { get; set; } // Adicione uma propriedade para o ID

        [JsonIgnore]
        [ForeignKey("MatrizId")]
        public virtual Matriz Matriz { get; set; } //private só altera dentro da classe

        [Required]
        public bool Ativo { get; set; } //private só altera dentro da classe

        public Ninhada() { } // Construtor padrão

        public Ninhada(string nome, int quantidade, DateTime dataNascimento, int matrizId)
        {
            Nome = nome;
            Quantidade = quantidade;
            DataNascimento = dataNascimento;
            MatrizId = matrizId;
            Ativo = true;
        }
    }

    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public string Salt { get; set; }

        public Usuario() { } // Construtor padrão

        public Usuario(string username, string password, DateTime dataNascimento, int matrizId, string salt)
        {
            Username = username;
            Password = password;
            Salt = salt;
            Ativo = true;
            
        }
    }
}
