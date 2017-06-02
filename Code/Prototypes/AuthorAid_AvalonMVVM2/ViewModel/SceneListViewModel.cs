using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using AuthorAid_AvalonMVVM2.Model;

namespace AuthorAid_AvalonMVVM2.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class SceneListViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary>
        public SceneListViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}
        }

        public ObservableCollection<Scene> OrderedSceneList
        {
            get
            {
                return new ObservableCollection<Scene>
                {
                    new Scene { Ordinal = 1, PercentComplete = 70, Title = "Scene 1", Summary = "Summary for Scene 1" },
                    new Scene { Ordinal = 2, PercentComplete = 70, Title = "Scene 2", Summary = "Summary for Scene 2" },
                    new Scene { Ordinal = 3, PercentComplete = 70, Title = "Scene 3", Summary = "Summary for Scene 3" },
                    new Scene { Ordinal = 4, PercentComplete = 70, Title = "Scene 4", Summary = "Summary for Scene 4" },
                    new Scene { Ordinal = 5, PercentComplete = 70, Title = "Scene 5", Summary = "Summary for Scene 5" }
                };
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean own resources if needed

        ////    base.Cleanup();
        ////}
    }
}