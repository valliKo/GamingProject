using GamingProject.Data;
using GamingProject.Model;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GamingProject.Repository
{
    public class GameRepository(GamingProjectContext context) : IGameInterface
    {
        public async Task<bool> CreateAsync(Game game)
        {
            context.Game.Add(game);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

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

        public async Task<IEnumerable<Game>> GetAllAsync()
        => await context!.Game.ToListAsync();

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
