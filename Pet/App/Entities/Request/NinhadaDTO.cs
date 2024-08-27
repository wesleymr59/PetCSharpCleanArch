using Pet.App.Entities.PgSQL;

namespace Pet.App.Entities.Request
{
    public class RequestNinhadaDTO
    {
        public string? Nome { get; set; }
        public int Quantidade { get; set; }

        public DateTime DataNascimento { get; set; }

        public int MatrizId { get; set; }
    }
}
