using GamingProject.Model;
using System.Numerics;

namespace GamingProject.Repository
{
    /// <summary>
    /// Create Interface
    /// </summary>
    public interface IGameInterface
    {
        //CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<bool> CreateAsync (Game game);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Game game);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Game>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PaginatedList<Game>> GetGames(int pageIndex, int pageSize);

    }
}
