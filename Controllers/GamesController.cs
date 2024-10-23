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
    [Route("[controller]")]
    [ApiController]
    public class GamesController(IGameInterface gameInterface) : ControllerBase
    {
        //Create
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
        [HttpPut("update")]
        public async Task<IActionResult> UpdateGameeDetails(Game game)
        {
            var result = await gameInterface.UpdateAsync(game);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        //Delete
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

        [HttpGet("getByPage")]
        public async Task<ActionResult> GetGameDetailsByPage(int pageIndex , int pageSize)
        {
            var gameDeatils = await gameInterface.GetGames(pageIndex, pageSize);
            if (!gameDeatils.Items.Any())
                return NotFound();
            else
                return Ok(gameDeatils);
        }

    }
}
