using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using System.Linq;
using System;


namespace MessageBoard.Controllers
{
  [Route("api/Messages")]
  [ApiController]

  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;
    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string message)
    {
      var query = _db.Messages.AsQueryable();

      if (message != null)
      {
        query = query.Where(e => e.Content == message);
      }

      return await query.ToListAsync();
    }
    //GET: api/Messages/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }

      return message;
    }
    // POST api/Messages
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message, string name)
    {
      var thisTopic = _db.Topics.Include(entry => entry.Messages).FirstOrDefault(entry => entry.TopicName == name);
      
      if (thisTopic != null)
      {
        message.Date = DateTime.Now;
        message.TopicId = thisTopic.TopicId;
        thisTopic.Messages.Add(message);
        _db.Topics.Update(thisTopic);    
        await _db.SaveChangesAsync();
      }
      else
      {
        return BadRequest();
      }
      return CreatedAtAction("Post", new { id = message.TopicId}, thisTopic);
    }

    // PUT: api/Messages/1  }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }
      _db.Entry(message).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }

      catch (DbUpdateConcurrencyException)
      {
        if(!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }
  }
}