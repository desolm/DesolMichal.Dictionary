using DesolMichal.Dictionary.Core.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DesolMichal.Dictionary.Core.Converters
{
    [ValueConversion(typeof(PartOfSpeech?), typeof(string))]
    public class PartOfSpeechToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (PartOfSpeech?)value switch
        {
            PartOfSpeech.Noun => "rzeczownik",
            PartOfSpeech.Pronoun => "zaimek",
            PartOfSpeech.Verb => "czasownik",
            PartOfSpeech.Adjective => "przymiotnik",
            PartOfSpeech.Adverb => "przysłówek",
            PartOfSpeech.Preposition => "przyimek",
            PartOfSpeech.Conjunction => "spójnik",
            PartOfSpeech.Interjection => "wykrzyknik",
            _ => null,
        };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
