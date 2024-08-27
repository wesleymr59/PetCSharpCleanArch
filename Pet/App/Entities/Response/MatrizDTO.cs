using Pet.App.Entities.PgSQL;

namespace Pet.App.Entities.Request
{
    public class MatrizResponseDTO<T>
    {
        public string? Nome { get; set; }
        public string? Cor { get; set; }
        public DateTime DataNascimento { get; set; }
    }

    public class NinhadaMatrizDTO
    {
        public MatrizDTO Matriz { get; set; }
        public List<NinhadaDTO> Ninhadas { get; set; }
    }

    public class MatrizDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public List<NinhadaDTO> Ninhadas { get; set; }
    }

    public class NinhadaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public int MatrizId { get; set; }
        public bool Ativo { get; set; }
    }
}