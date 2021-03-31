using System;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int TopicId { get; set; }
  }
}