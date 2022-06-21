using DesolMichal.Dictionary.Modules.Dictionary;
using DesolMichal.Dictionary.Services;
using DesolMichal.Dictionary.Services.Interfaces;
using DesolMichal.Dictionary.Views;
using DryIoc.Microsoft.DependencyInjection.Extension;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Syncfusion.SfSkinManager;
using System.Windows;

namespace DesolMichal.Dictionary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            SfSkinManager.ApplyStylesOnApplication = true;
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDictionaryService, WordsApiDictionaryService>();
            containerRegistry.GetContainer().RegisterServices(services =>
            {
                services.AddHttpClient("WordsAPI", httpClient =>
                {
                    httpClient.BaseAddress = new System.Uri("https://wordsapiv1.p.rapidapi.com/");
                    // Aplikacja nie będzie działać prawidłowo bez wprowadzenia klucza do WordsAPI.
                    // Ja swojego klucza nie mogę udostępnić ponieważ kod udostępniam na GitHubie gdzie każdy może go zobaczyć.
                    // Klucz można otrzymać rejestrując się na tej stronie https://rapidapi.com/dpventures/api/wordsapi/pricing
                    httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "TUTAJ NALEŻY PODAĆ KLUCZ DO API");
                    httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "wordsapiv1.p.rapidapi.com");
                });
            });
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<DictionaryModule>();
        }
    }
}
