using GamingProject.Model;
using System.Numerics;

namespace GamingProject.Repository
{
    public interface IGameInterface
    {
        //CRUD
        Task<bool> CreateAsync (Game game);
        Task<bool> UpdateAsync(Game game);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<PaginatedList<Game>> GetGames(int pageIndex, int pageSize);

    }
}
