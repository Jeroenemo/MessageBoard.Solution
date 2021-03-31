using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Models;
using System;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TopicsController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public TopicsController(MessageBoardContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Topic>>> Get(string name)
    {
      var query = _db.Topics.Include(entry => entry.Messages).AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.TopicName == name);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<Topic>> GetTopic(string name)
    {
      var thisId = _db.Topics.FirstOrDefault(entry => entry.TopicName == name).TopicId;
      var Topic = await _db.Topics.FindAsync(thisId);

      if (Topic == null)
      {
        return NotFound();
      }

      return Topic;
    }

    [HttpPost]
    public async Task<ActionResult<Topic>> Post(Topic topic)
    {
      if ((_db.Topics.FirstOrDefault(entry => entry.TopicName == topic.TopicName)) != null)
      {
        return BadRequest();
      }
      else {
      _db.Topics.Add(topic);
      await _db.SaveChangesAsync();
      }
      return CreatedAtAction("Post", new { id = topic.TopicId }, topic);
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteMessage(int id)
    // {
    //   var message = await _db.Messages.FindAsync(id);
    //   if (message == null)
    //   {
    //     return NotFound();
    //   }

    //   _db.Messages.Remove(message);
    //   await _db.SaveChangesAsync();

    //   return NoContent();
    // }

    // private bool MessageExists(int id)
    // {
    //   return _db.Messages.Any(e => e.MessageId == id);
    // }
  
    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, Message message)
    // {
    //   if (id != message.MessageId)
    //   {
    //     return BadRequest();
    //   }

    //   _db.Entry(message).State = EntityState.Modified; //??

    //   try
    //   {
    //     await _db.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!MessageExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }

    //   return NoContent();
    // }
  }
}
