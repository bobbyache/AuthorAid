/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TestModelViewLocator"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using TestModelViewLocator.Model.Repository;
using Ninject.Injection;
using Ninject;
using Ninject.Modules;

namespace TestModelViewLocator.ViewModel
{
    public class RunTimeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStoryRepository>().To<StoryRepository>();
        }
    }
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private  StandardKernel kernel;
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //}
            //else
            //{
            //    // Create run time view services and models
            //}

            kernel = new StandardKernel(new RunTimeModule());
        }

        public MainViewModel Main
        {
            get
            {
                return kernel.Get<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}