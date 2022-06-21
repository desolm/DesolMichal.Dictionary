using System.Collections.Generic;

namespace DesolMichal.Dictionary.Core.Models
{
    public class WordDefinition
    {
        public string Definition { get; set; }
        public PartOfSpeech? PartOfSpeech { get; set; }
        public List<string> Synonyms { get; set; }
        public string Example { get; set; }
    }
    public enum PartOfSpeech
    {
        Noun,
        Pronoun,
        Verb,
        Adjective,
        Adverb,
        Preposition,
        Conjunction,
        Interjection
    }
}