using System.Collections.Generic;

namespace GeneratoryParser.Models
{
    public class Data
    {
        public string question { get; set; }
        public int id { get; set; }
        public IList<Comment> comments { get; set; }
        public IList<Answer> answers { get; set; }
    }
}