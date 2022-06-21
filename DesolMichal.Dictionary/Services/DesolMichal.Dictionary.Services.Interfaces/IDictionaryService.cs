using Ardalis.Result;
using DesolMichal.Dictionary.Core.Models;
using System.Threading.Tasks;

namespace DesolMichal.Dictionary.Services.Interfaces
{
    public interface IDictionaryService
    {
        public Task<Result<Word>> GetWordAsync(string word);
    }
}
