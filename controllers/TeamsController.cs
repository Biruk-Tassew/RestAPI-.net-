using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restAPI.Data;
using restAPI.Models;

namespace restAPI.Controllers;

[Route(template:"api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private static ApiDbContext _contex;
    public TeamsController (ApiDbContext context)
    {
        _contex = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teams = await _contex.Teams.ToListAsync();
        return Ok(teams);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get (int Id){
        var team = await _contex.Teams.FirstOrDefaultAsync(t =>  t.Id == Id);

        if (team == null)
            return BadRequest(error: "Invalid Id");

        return Ok(team);

    }

    [HttpPost]
    public async Task<IActionResult> Post (Team team) {
        await _contex.AddAsync(team);
        await _contex.SaveChangesAsync();

        return CreatedAtAction("Get", team .Id, team);
    }

    [HttpPatch("{Id}")]
    public async Task<IActionResult> Patch (int Id, Team n_team)
    {
        var team = await _contex.Teams.FirstOrDefaultAsync(t => t.Id == Id);

        if (team == null)
            return BadRequest(error: "Invalid Id");

        team.Name = n_team.Name;
        await _contex.SaveChangesAsync();
        return Ok(team);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete (int Id)
    {
        var team = await _contex.Teams.FirstOrDefaultAsync(t => t.Id == Id);

        if (team == null)
            return BadRequest(error: "Invalid Id");

        _contex.Remove(team);
        await _contex.SaveChangesAsync();

        return NoContent();
    }

}