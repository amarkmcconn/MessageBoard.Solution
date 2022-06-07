using System;

namespace MessageBoard.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}