using WebPCP.Domain;

namespace WebPCP.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IList<Usuario>> GetAllAsync();
        Task<Usuario> GetAsync(int codigo);
        Task<Usuario> GetByUsernameAsync(string username);
        Task<bool> CreateAsync(Usuario usuario);
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int codigo);
    }
}
