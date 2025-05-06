using CafeteriaApp.Business;
using CafeteriaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CafeController : ControllerBase
{
    private readonly ILogger<CafeController> _logger;
    // TODO: usar el logger abajo, por ejemplo para POST, PUT y DELETE
    private readonly ICafeService _cafeService;

    public CafeController(ILogger<CafeController> logger,
                          ICafeService cafeService)
    {
        _logger = logger;
        _cafeService = cafeService;
    }

    [HttpGet(Name = "GetAllCafes")]
    public ActionResult<IEnumerable<Cafe>> GetCafes()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var cafes = _cafeService.GetAllCafes();
            return Ok(cafes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("{id}", Name = "GetCafe")]
    public IActionResult GetCafe(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafe = _cafeService.GetCafeById(id);
            return Ok(cafe);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"El cafe de id {id} no existe");
        }
    }

    // POST
    [Authorize]
    [HttpPost]
    public IActionResult CreateCafe([FromBody] CafeCreateDto cafeCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!_cafeService.EsAdmin(HttpContext.User))
        {
            return Forbid();
        }

        try
        {
            var cafe = _cafeService.CreateCafe(cafeCreateDto);
            return Ok(cafe.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT
    [Authorize]
    [HttpPut("{id}")]
    public IActionResult UpdateCafe(int id,
                                    [FromBody] CafeCreateDto cafeCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!_cafeService.EsAdmin(HttpContext.User))
        {
            return Forbid();
        }

        try
        {
            _cafeService.UpdateCafe(id, cafeCreateDto);
            return Ok(id);
        }

        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // DELETE
    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeleteCafe(int id)
    {
        if (!_cafeService.EsAdmin(HttpContext.User))
        {
            return Forbid();
        }

        try
        {
            _cafeService.DeleteCafe(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

