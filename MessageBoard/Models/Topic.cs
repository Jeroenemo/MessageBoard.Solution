using System;
using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Topic
  {
    public Topic()
    {
      this.Messages = new HashSet<Message>();
    }
    public int TopicId { get; set; }
    public string TopicName { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
  }
}