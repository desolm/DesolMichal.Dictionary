using DesolMichal.Dictionary.Core.Models;
using DesolMichal.Dictionary.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace DesolMichal.Dictionary.Modules.Dictionary.ViewModels
{
    public class DictionaryViewModel : BindableBase
    {
        private readonly IDictionaryService _dictionaryService;

        private DelegateCommand searchWordCommand;
        public DelegateCommand SearchWordCommand =>
            searchWordCommand ?? (searchWordCommand = new DelegateCommand(ExecuteSearchWordCommand, () => !string.IsNullOrEmpty(InputWord)).ObservesProperty(() => InputWord));

        async void ExecuteSearchWordCommand()
        {
            IsBusy = true;
            var result = await _dictionaryService.GetWordAsync(InputWord);
            if (!result.IsSuccess)
            {
                if (result.Status == Ardalis.Result.ResultStatus.NotFound)
                {
                    ErrorMessage = "Poszukiwane słowo nie zostało znalezione.";
                }
                else
                {
                    ErrorMessage = string.Join(", ", result.Errors);
                }
            }
            else
            {
                Word = result.Value;
                ErrorMessage = null;
            }
            IsBusy = false;
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string inputWord;
        public string InputWord
        {
            get { return inputWord; }
            set { SetProperty(ref inputWord, value); }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private Word word;
        public Word Word
        {
            get { return word; }
            set { SetProperty(ref word, value); }
        }

        public DictionaryViewModel(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }
    }
}
