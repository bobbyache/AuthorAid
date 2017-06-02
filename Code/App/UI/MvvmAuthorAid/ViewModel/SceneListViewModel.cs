using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Domain.Services;
using Domain.Repositories;
using Domain.Entities;
using GalaSoft.MvvmLight.Command;
using CygX1.AuthorAid.Windows.ViewModel;

namespace CygX1.AuthorAid.Windows.ViewModel
{
    public class SceneListViewModel : ViewModelBase
    {
        private MainStoryService storyService;
        //private Scene.SceneRevision[] sceneRevisions;

        public SceneListViewModel(MainStoryService storyService)
        {
            this.storyService = storyService;
            //this.sceneRevisions = Scene.GetSceneRevisionPhases();

            if (this.storyService.OrderedScenes.Count > 0)
                SelectedScene = this.storyService.OrderedScenes[0];

            this.MoveSceneUpCommand = new RelayCommand(MoveSelectionUp, CanMoveUp);
            this.MoveSceneDownCommand = new RelayCommand(MoveSelectionDown, CanMoveDown);
        }

        #region Commands

        public RelayCommand MoveSceneUpCommand
        {
            get;
            private set;
        }

        public RelayCommand MoveSceneDownCommand
        {
            get;
            private set;
        }

        #endregion

        #region Properties

        public ObservableCollection<Scene> OrderedScenes
        {
            get { return storyService.OrderedScenes; }
        }

        public const string SelectedScenePropertyName = "SelectedScene";
        private Scene selectedScene = null;
        public Scene SelectedScene
        {
            get { return selectedScene; }
            set
            {
                if (selectedScene != value)
                {
                    //RaisePropertyChanging(SelectedScenePropertyName);
                    selectedScene = value;
                    RaisePropertyChanged(SelectedScenePropertyName);
                }
            }
        }

        public Scene FirstScene { get { return this.storyService.FirstScene; } }
        public Scene LastScene { get { return this.storyService.LastScene; } }

        public Scene.SceneRevision[] SceneRevisionList
        {
            //get { return sceneRevisions; }
            get { return Scene.GetSceneRevisionPhases(); }
        }

        #endregion

        #region Public Methods

        public void AppendToEnd(Scene newScene)
        {
            this.storyService.AddScene(newScene);
            SelectedScene = newScene;
        }

        public void RemoveSelection()
        {
            Scene toBeSelected;


            if (this.storyService.CanMoveSceneDown(this.SelectedScene))
                toBeSelected = this.storyService.GetNextScene(this.SelectedScene);

            else if (this.storyService.CanMoveSceneUp(this.SelectedScene))
                toBeSelected = this.storyService.GetPreviousScene(this.SelectedScene);
            else
                toBeSelected = null;

            this.storyService.RemoveScene(this.SelectedScene);
            this.SelectedScene = toBeSelected;
        }

        #endregion

        #region Private Methods

        private void MoveSelectionUp()
        {
            if (CanMoveUp())
            {
                Scene scene = this.SelectedScene;
                this.storyService.MoveSceneUp(this.SelectedScene);
                this.SelectedScene = scene;
            }
        }

        private void MoveSelectionDown()
        {
            if (CanMoveDown())
            {
                Scene scene = this.SelectedScene;
                this.storyService.MoveSceneDown(this.SelectedScene);
                this.SelectedScene = scene;
            }
        }

        private bool CanMoveUp()
        {
            return this.storyService.CanMoveSceneUp(this.SelectedScene);
        }

        private bool CanMoveDown()
        {
            return this.storyService.CanMoveSceneDown(this.SelectedScene);
        }

        #endregion
    }
}