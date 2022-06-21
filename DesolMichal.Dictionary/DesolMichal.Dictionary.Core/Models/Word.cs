using System.Collections.Generic;

namespace DesolMichal.Dictionary.Core.Models
{
    public class Word
    {
        public string Name { get; set; }
        public List<WordDefinition> Definitions { get; set; }
    }
}
