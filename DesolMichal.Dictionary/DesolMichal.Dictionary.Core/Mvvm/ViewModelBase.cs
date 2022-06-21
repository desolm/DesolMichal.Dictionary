using Prism.Mvvm;
using Prism.Navigation;

namespace DesolMichal.Dictionary.Services.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
