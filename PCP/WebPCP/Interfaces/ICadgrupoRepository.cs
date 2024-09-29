using WebPCP.Domain;

namespace WebPCP.Interfaces
{
    public interface ICadgrupoRepository
    {
        Task<IList<Cadgrupo>> GetAllAsync();
        Task<Cadgrupo> GetAsync(int codigo);
        Task<Cadgrupo> GetByCadgrupodescricaoAsync(string descricao);
        Task<bool> CreateAsync(Cadgrupo cadgrupo);
        Task<bool> UpdateAsync(Cadgrupo cadgrupo);
        Task<bool> DeleteAsync(int codigo);

    }
}
