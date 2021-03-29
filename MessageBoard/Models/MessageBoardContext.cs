using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>()
        .HasData(
          new Message { MessageId = 1, Topic = "Starwars", Content = "JarJar Binks is a Sith Lord" },
          new Message { MessageId = 2, Topic = "Starwars", Content = "Liam Neeson is the greatest Jedi" },
          new Message { MessageId = 3, Topic = "Social Media", Content = "Tumblr is the perfect anti capitalist social media site because the user base is basically impossible to advertise to" },
          new Message { MessageId = 4, Topic = "Animals", Content = "Animalitos are CUTE" },
          new Message { MessageId = 5, Topic = "Animals", Content = "Animalitos are NOT cute. #cancelled" }
        );
    }
    public DbSet<Message> Messages { get; set; }

  }
}