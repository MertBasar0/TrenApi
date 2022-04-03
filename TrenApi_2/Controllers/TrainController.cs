using Microsoft.AspNetCore.Mvc;
using TrenApi_2.Models;
using TrenApi_2.Services;

namespace TrenApi_2.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainController : ControllerBase
{
    public TrainController()
    {
    }

    [HttpGet]
    public ActionResult<List<Train>> GetAll() =>
        TrainService.GetAll();


    [HttpGet("{id}")]
    public ActionResult<Train> Get(int id)
    {
        var train = TrainService.Get(id);

        if (train == null)
        {
            return NotFound();
        }
        else
        {
            return train;
        }
    }

    [HttpPost]
    public IActionResult Create(Train train)
    {
        TrainService.Add(train);
        return CreatedAtAction(nameof(Create), new {id = train.Id}, train);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var train = TrainService.Get(id);

        if (train is null)
        {
            return NotFound();
        }
        else
        {
            TrainService.Delete(id);
            return NoContent();
        }
    }
 }

