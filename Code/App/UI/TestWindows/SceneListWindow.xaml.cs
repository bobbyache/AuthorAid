using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestWindows.Helpers;
using Domain.Repositories;
using Domain.Services;
using CygX1.AuthorAid.Windows.ViewModel;

namespace TestWindows
{
    /// <summary>
    /// Interaction logic for SceneListWindow.xaml
    /// </summary>
    public partial class SceneListWindow : Window
    {
        public SceneListWindow()
        {
            InitializeComponent();
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStoryService = new MainStoryService(repository);
            SceneListViewModel sceneListViewModel = new SceneListViewModel(mainStoryService);

            this.DataContext = sceneListViewModel;
            this.OrderedSceneListview.ItemsSource = sceneListViewModel.OrderedScenes;
        }
    }
}
