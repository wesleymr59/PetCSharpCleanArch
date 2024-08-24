using Pet.App.Entities.PgSQL;

namespace Pet.App.Gateways
{
    public interface IRepositoryInterface
    {

        Task<Matriz> GetByIdAsync(int id);
    }
}
