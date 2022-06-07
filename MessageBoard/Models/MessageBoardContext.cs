using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
      public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
          : base(options)
      {
      }

      public DbSet<Message> Messages { get; set; }
      // protected override void OnModelCreating(ModelBuilder builder)
      // {
      //   builder.Entity<Message>()
      //       .HasData(
      //           new Message { MessageId = 1, Description = "This is a test message", Group = "TEST", Date = "19//03//2013T18:06", Author = "Mark" },
      //           new Message { MessageId = 2, Description = "This is a test message", Group = "TEST 1", Date = "2022-01-01T10:10:10", Author = "Mark" },
      //           new Message { MessageId = 3, Description = "This is a test message", Group = "TEST", Date = "2022-01-01T10:10:10", Author = "Mark" },
      //           new Message { MessageId = 4, Description = "This is a test message", Group = "TEST 1", Date = "2022-01-01T10:10:10", Author = "Jack" },
      //           new Message { MessageId = 5, Description = "This is a test message", Group = "TEST", Date = "2022-01-01T10:10:10", Author = "Jack" }
      //       );
      // }
    }
}