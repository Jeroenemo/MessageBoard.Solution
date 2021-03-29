namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Topic { get; set; }
    public string Content { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
  }
}