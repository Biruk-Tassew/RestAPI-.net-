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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get (int id){
        var team = await _contex.Teams.FirstOrDefaultAsync(t => t.id == id);

        if (team == null)
            return BadRequest(error: "Invalid Id");

        return Ok(team);

    }

    [HttpPost]
    public async Task<IActionResult> Post (Team team) {
        await _contex.AddAsync(team);
        await _contex.SaveChangesAsync();

        return CreatedAtAction("Get", team.id, team);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch (int id, string name)
    {
        var team = await _contex.Teams.FirstOrDefaultAsync(t => t.id == id);

        if (team == null)
            return BadRequest(error: "Invalid id");

        team.Name = name;
        await _contex.SaveChangesAsync();
        return Ok(team);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete (int id)
    {
        var team = await _contex.Teams.FirstOrDefaultAsync(t => t.id == id);

        if (team == null)
            return BadRequest(error: "Invalid id");

        _contex.Remove(team);
        await _contex.SaveChangesAsync();

        return NoContent();
    }

}