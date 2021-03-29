using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public virtual DbSet<Group> Groups { get; set; }
    public DbSet<Message> Messages { get; set; }
    public MessageBoardContext(DbContextOptions options) : base(options) { }

    // LazyLoading extension not installed YET!

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   optionsBuilder.UseLazyLoadingProxies();
    // }
  }
}