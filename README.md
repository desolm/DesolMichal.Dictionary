
# Słownik języka angielskiego
W tym repozytorium znajduje się kod mojej aplikacji zaliczeniowej na zajęcia z programowania obiektowego.
## Instalacja aplikacji
Instalator aplikacji dostępny jest pod adresem [zaliczenie-michal-desol.tk](http://zaliczenie-michal-desol.tk/).  
Aplikacja pobrana i zainstalowana z powyższego adresu zawiera w sobie wszystkie potrzebne zależności i nie jest wymagana jej konfiguracja.
## Kompilacja lokalna
 - Należy pobrać kod źródłowy korzystając z przycisków na górze strony lub poleceniem:  
`git clone https://github.com/desolm/DesolMichal.Dictionary.git`
 - Przed uruchomieniem aplikacji należy uzyskać klucz do WordsAPI i wprowadzić go w pliku "DesolMichal.Dictionary\DesolMichal.Dictionary\App.xaml.cs" w zaznaczonym miejscu.  
**Bez prawidłowego klucza aplikacja uruchomi się natomiast każda próba odszukania definicji słowa zakończy się błędem!**
 - W katalogu, gdzie został pobrany kod należy wywołać polecenie:  
`dotnet run --project DesolMichal.Dictionary/DesolMichal.Dictionary/DesolMichal.Dictionary.csproj`
## Wymagania wstępne
 - .NET 6
 - Klucz do WordsAPI (dostępny na stronie [WordsAPI](https://rapidapi.com/dpventures/api/wordsapi/pricing))
## Informacje dotyczące oprogramowania Syncfusion Essential Studio for WPF
Aplikacja wykorzystuje kontrolki nalężące do pakietu Syncfusion Essential Studio for WPF. Po uruchomieniu aplikacji może pojawić się komunikat informujący o braku licencji na pakiet Essential Studio. Osobiście posiadam odpowiednią licencję Community na powyższy pakiet natomiast ponieważ kod udostępniam publicznie nie uwzględniłem klucza licencyjnego w kodzie aplikacji. Licencję na produkt Syncfusion Essential Studio for WPF można uzyskać bezpłatnie na stronie [syncfusion.com](https://www.syncfusion.com/products/communitylicense). Brak licencji nie wpływa negatywnie na działanie aplikacji.
## Funkcje aplikacji
 - Nowoczesny, przejrzysty interfejs użytkownika
 - Walidacja danych wejściowych oraz obsługa błędów
 - Integracja z prawdziwym słownikiem języka angielskiego
 - Wzorzec [MVVM](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel) pozwalający na oddzielenie wyglądu aplikacji od logiki biznesowej
 - Luźno sprzężone komponenty aplikacji umożliwiające jej łatwą rozbudowę
 - Oddzielenie definicji usług aplikacji od ich implementacji z wykorzystaniem [wstrzykiwania zależności](https://en.wikipedia.org/wiki/Dependency_injection)
## Wykorzystane pakiety
 - [Prism](https://github.com/PrismLibrary/Prism)
 - [Syncfusion Essential Studio for WPF](https://www.syncfusion.com/wpf-controls)
 - [Result](https://github.com/ardalis/Result)
 - [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http/)
 - [Prism.Extensions.ServiceCollection](https://github.com/juner/Prism.Extensions.ServiceCollection)

*Michał Desol (129908)*
