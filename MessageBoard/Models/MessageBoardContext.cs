using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options) { }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //   builder.Entity<Message>()
    //     .HasData(
    //       new Topic { TopicId = 1, TopicName = "Starwars" },
    //       new Topic { TopicId = 2, TopicName = "Social Media" },
    //       new Topic { TopicId = 3, TopicName = "Animas" },
    //       new Message { MessageId = 1, TopicId = 1, Content = "JarJar Binks is a Sith Lord" },
    //       new Message { MessageId = 2, TopicId = 1, Content = "Liam Neeson is the greatest Jedi" },
    //       new Message { MessageId = 3, TopicId = 2, Content = "Tumblr is the perfect anti capitalist social media site because the user base is basically impossible to advertise to" },
    //       new Message { MessageId = 4, TopicId = 3, Content = "Animalitos are CUTE" },
    //       new Message { MessageId = 5, TopicId = 3, Content = "Animalitos are NOT cute. #cancelled" }
    //     );
    // }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Topic> Topics { get; set; }

  }
}