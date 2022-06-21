using DesolMichal.Dictionary.Modules.Dictionary.Views;
using DesolMichal.Dictionary.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DesolMichal.Dictionary.Modules.Dictionary
{
    public class DictionaryModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public DictionaryModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "DictionaryView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DictionaryView>();
        }
    }
}