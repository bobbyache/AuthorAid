using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Windows.ViewModel;
using Domain.Repositories;
using Domain.Services;

namespace ViewModelTests.Helpers
{
    public class ViewModelHelper
    {
        public static SceneListViewModel GetSceneListViewModel()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStoryService = new MainStoryService(repository);
            SceneListViewModel sceneListViewModel = new SceneListViewModel(mainStoryService);
            return sceneListViewModel;
        }
    }
}
