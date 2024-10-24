using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingProject.Data;
using GamingProject.Model;
using GamingProject.Repository;

namespace GamingProject.Controllers
{
    /// <summary>
    /// Add Controller
    /// </summary>
    /// <param name="gameInterface"></param>
    [Route("[controller]")]
    [ApiController]
    public class GamesController(IGameInterface gameInterface) : ControllerBase
    {
        //Create
        /// <summary>
        /// add Game Details
        /// </summary>
        /// <param name="game"></param>
        /// <returns> returns created status</returns>
        [HttpPost("add")]
        public async Task<IActionResult> Create(Game game)
        {
            var result = await gameInterface.CreateAsync(game);
            if (result)
                return CreatedAtAction(nameof(Create), new { id = game.ID }, game);
            else
                return BadRequest();
        }
        //update
        /// <summary>
        /// Update particular Game Details based on Id
        /// </summary>
        /// <param name="game"></param>
        /// <returns> returns Ok Result</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateGameDetails(Game game)
        {
            var result = await gameInterface.UpdateAsync(game);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        //Delete
        /// <summary>
        /// Delete Particular Game Data based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> returns NoContent Status</returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await gameInterface.DeleteAsync(id);
            if (result)
                return NoContent();
            else
                return NotFound();
        }

        //Read All
        /// <summary>
        /// Get All the Games Details
        /// </summary>
        /// <returns> returns all the Games data</returns>
        [HttpGet("get")]
        public async Task<IActionResult> GetGames()
        {
            var games = await gameInterface.GetAllAsync();
            if (!games.Any())
                return NotFound();
            else
                return Ok(games);
        }

        //pagination
        /// <summary>
        /// returns Gaming Details by Pagination
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns> returns gameing details based on page number</returns>
        [HttpGet("getByPage")]
        public async Task<ActionResult> GetGameDetailsByPage(int pageIndex =1 , int pageSize =10)
        {
            var gameDeatils = await gameInterface.GetGames(pageIndex, pageSize);
            if (!gameDeatils.Items.Any())
                return NotFound();
            else
                return Ok(gameDeatils);
        }

    }
}
