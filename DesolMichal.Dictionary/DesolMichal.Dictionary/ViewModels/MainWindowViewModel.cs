using Prism.Mvvm;

namespace DesolMichal.Dictionary.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Słownik języka angielskiego - Michał Desol (129908)";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
