using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Domain.Positioning;
using System.Collections.ObjectModel;
using CygX1.PersistentObjects;


namespace Domain.Services
{
    public class MainStoryService
    {
        private IRepository repositoryInterface;

        public MainStoryService(IRepository repositoryInterface)
        {
            this.repositoryInterface = repositoryInterface;
            orderedScenes = new PositionableList<Scene>();
            orderedScenes.InitializeList(repositoryInterface.Scenes.GetScenes());
        }

        private PositionableList<Scene> orderedScenes;

        public ObservableCollection<Scene> OrderedScenes
        {
            get { return orderedScenes.ObservableItemsList; }
        }

        public Scene FirstScene
        {
            get { return orderedScenes.FirstItem; }
        }

        public Scene LastScene
        {
            get { return orderedScenes.LastItem; }
        }

        public bool ValidScenePositioning 
        { 
            get { return orderedScenes.ValidPositioning; } 
        }

        public void FixSceneOrder()
        {
            orderedScenes.AutoFixPositioning();
            repositoryInterface.Scenes.UpdateScenes(orderedScenes.ItemsList);
        }

        public void MoveSceneUp(Scene scene)
        {
            orderedScenes.MoveUp(scene);
            repositoryInterface.Scenes.UpdateScenes(orderedScenes.ItemsList);
        }

        public void MoveSceneDown(Scene scene)
        {
            orderedScenes.MoveDown(scene);
            repositoryInterface.Scenes.UpdateScenes(orderedScenes.ItemsList);
        }

        public void MoveSceneTo(Scene scene, int position)
        {
            orderedScenes.MoveTo(scene, position);
            repositoryInterface.Scenes.UpdateScenes(orderedScenes.ItemsList);
        }

        public Scene GetPreviousScene(Scene scene)
        {
            return orderedScenes.ItemAbove(scene);
        }

        public Scene GetNextScene(Scene scene)
        {
            return orderedScenes.ItemBelow(scene);
        }

        public bool CanMoveSceneUp(Scene scene)
        {
            return orderedScenes.CanMoveUp(scene);
        }

        public bool CanMoveSceneDown(Scene scene)
        {
            return orderedScenes.CanMoveDown(scene);
        }

        public bool CanMoveSceneTo(Scene scene, int position)
        {
            return orderedScenes.CanMoveTo(scene, position);
        }

        public void RemoveScene(Scene scene)
        {
            orderedScenes.Remove(scene);
            scene.CurrentState = PersistableEntityStateEnum.Deleted;
            repositoryInterface.Scenes.UpdateScene(scene);
        }

        public void AddScene(Scene scene)
        {
            orderedScenes.Insert(scene);
            repositoryInterface.Scenes.UpdateScene(scene);
        }
    }
}
