using Ardalis.Result;
using DesolMichal.Dictionary.Core.Models;
using DesolMichal.Dictionary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesolMichal.Dictionary.Services
{
    public class WordsApiDictionaryService : IDictionaryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WordsApiDictionaryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Result<Word>> GetWordAsync(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return Result<Word>.Invalid(new List<ValidationError>()
                {
                    new ValidationError()
                    {
                        Identifier = nameof(word),
                        ErrorMessage = "Szukane słowo nie może być puste."
                    }
                });
            }

            try
            {
                var httpClient = _httpClientFactory.CreateClient("WordsAPI");
                var response = await httpClient.GetAsync($"words/{word}");
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return Result<Word>.NotFound();
                    }
                    return Result<Word>.Error("Serwer zwrócił nieprawidłową odpowiedź.");
                }
                using (var data = await response.Content.ReadAsStreamAsync())
                {
                    using (var document = await JsonDocument.ParseAsync(data))
                    {
                        return Result<Word>.Success(new Word()
                        {
                            Name = document.RootElement.GetProperty("word").GetString(),
                            Definitions = document.RootElement.GetProperty("results").EnumerateArray().Select(definition => new WordDefinition()
                            {
                                Definition = definition.GetProperty("definition").GetString(),
                                Example = definition.TryGetProperty("examples", out _) && definition.GetProperty("examples").EnumerateArray().Any() ? definition.GetProperty("examples").EnumerateArray().First().GetString() : null,
                                PartOfSpeech = definition.GetProperty("partOfSpeech").GetString() switch
                                {
                                    "noun" => PartOfSpeech.Noun,
                                    "pronoun" => PartOfSpeech.Pronoun,
                                    "verb" => PartOfSpeech.Verb,
                                    "adjective" => PartOfSpeech.Adjective,
                                    "adverb" => PartOfSpeech.Adverb,
                                    "preposition" => PartOfSpeech.Preposition,
                                    "conjunction" => PartOfSpeech.Conjunction,
                                    "interjection" => PartOfSpeech.Interjection,
                                    _ => null
                                },
                                Synonyms = definition.TryGetProperty("synonyms", out _) ? definition.GetProperty("synonyms").EnumerateArray().Select(synonym => synonym.GetString()).ToList() : null
                            }).ToList()
                        }); ;
                    }
                }
            }
#pragma warning disable CS0168 // Zmienna jest zadeklarowana, ale nie jest nigdy używana
            catch (HttpRequestException e)
            {
                return Result<Word>.Error("Wystąpił problem podczas komunikacji z serwerem. Sprawdź połączenie sieciowe i spróbuj ponownie.");
            }
            catch (TaskCanceledException e)
            {
                return Result<Word>.Error("Serwer nie odpowiedział w wyznaczonym czasie. Spróbuj ponownie później.");
            }
            catch (Exception e)
            {
                return Result<Word>.Error("Wystąpił nieznany błąd.");
            }
#pragma warning restore CS0168 // Zmienna jest zadeklarowana, ale nie jest nigdy używana
        }
    }
}
