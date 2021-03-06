using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    // GET api/Messages
    [HttpGet]
    public async Task<List<Message>> Get(string groups, string authors, DateTime date)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();
      if (groups != null)
      {
        query = query.Where(entry => entry.Group == groups);
      }
      if (authors != null)
      {
        query = query.Where(entry => entry.Author == authors);
      }
      if (date != DateTime.MinValue)
      {
        query = query.Where(entry => entry.Date == date);
      }
      return await query.ToListAsync();
    }

    // POST api/Messages
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId}, message);
    }
    // GET: api/Messages/5
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
        // PUT: api/Messages/5
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
        if (!MessageExists(id))
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
    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }
    // DELETE: api/Messages/5
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
  }
}
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using MessageBoard.Models;
// using System.Linq;
// using System;

// namespace MessageBoard.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class MessagesController : ControllerBase
//   {
//     private readonly MessageBoardContext _db;
//     public MessagesController(MessageBoardContext db)
//     {
//       _db = db;
//     }
//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Message>>> Get(string group, string author, DateTime date)
//     {
//       var query = _db.Messages.AsQueryable();
//       if(group != null)
//       {
//         query = query.Where(e => e.Group == group);
//       }
//       if(author != null)
//       {
//         query = query.Where(e => e.Author == author);
//       }
//       if(date != DateTime.MinValue)
//       {
//         query = query.Where(e => e.Date == date);
//       }
//       return await query.ToListAsync();
//     }
//     [HttpPost]
//     public async Task<ActionResult<Message>> Post( Message message)
//     {
//       _db.Messages.Add(message);
//       await _db.SaveChangesAsync();
//       return CreatedAtAction("Post",new {id =message.MessageId},message);
//     }
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Message>> GetMessage(int id)
//     {
//       var message= await _db.Messages.FindAsync(id);
//       if(message == null)
//       {
//         return NotFound();
//       }
//       return message;

//     }
//     [HttpPut("{id}")]
//     public async Task<IActionResult> Put(int id, Message message)
//     {
//       if(id != message.MessageId)
//       {
//         return BadRequest();
//       }
//       _db.Entry(message).State = EntityState.Modified;
//       try
//       {
//         await _db.SaveChangesAsync();
//       }
//       catch (DbUpdateConcurrencyException)
//       {
//         if(!MessageExists(id))
//         {
//           return NotFound();
//         }
//         else
//         {
//           throw;
//         }
//       }
//       return NoContent();
//     }
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteMessage(int id)
//     {
//       var message = await _db.Messages.FindAsync(id);
//       if(message == null)
//       {
//         return NotFound();
//       }
//       _db.Messages.Remove(message);
//       await _db.SaveChangesAsync();
//       return NoContent();
//     }
//     private bool MessageExists(int id)
//     {
//       return _db.Messages.Any(e => e.MessageId == id);
//     }
//   }
// }