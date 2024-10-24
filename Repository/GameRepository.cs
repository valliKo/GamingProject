using GamingProject.Data;
using GamingProject.Model;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GamingProject.Repository
{
    /// <summary>
    /// Inherit Game Interface
    /// </summary>
    /// <param name="context"></param>
    public class GameRepository(GamingProjectContext context) : IGameInterface
    {
        /// <summary>
        /// Implement Create Method
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(Game game)
        {
            context.Game.Add(game);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
        /// <summary>
        /// Implement Delete Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var getGame = await context.Game.FirstOrDefaultAsync(s => s.ID == id);
            if (getGame != null)
            {
                context.Game.Remove(getGame);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }
        /// <summary>
        /// Implement Get Game Details Method
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Game>> GetAllAsync()
        => await context!.Game.ToListAsync();
        /// <summary>
        /// Implement Update Method
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Game game)
        {
            var getGame = await context.Game.FirstOrDefaultAsync(s => s.ID == game.ID);
            if (getGame != null)
            {
                getGame.Title = game.Title;
                getGame.Description = game.Description;
                getGame.Price = game.Price;
                getGame.StockQuantity = game.StockQuantity;
                getGame.Genre = game.Genre;
                getGame.ReleaseDate = game.ReleaseDate;
                var result = await context.SaveChangesAsync();
                return result>0;
            }
            return false;
        }
        /// <summary>
        /// Implement Pagination Method, requires pageIndex and pageSize
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PaginatedList<Game>> GetGames(int pageIndex, int pageSize)
        {
            var games = await context.Game
                .OrderBy(b => b.ID)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await context.Game.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Game>(games, pageIndex, totalPages);
        }

    }
}
