using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using Domain.Positioning;
using System.IO;

namespace Domain.Entities
{
    // current problem: SceneVersion will need to know about it's own data. So here when we go "GetVersion", we're only getting the basic version properties, what about the
    // deliverable text and other files that will be attached to the version. We're probably going to have to move the "Editor" to the Version, rather than the
    // scene. We'll always be working on "Versions" of a scene.

    public class SceneEditor
    {
        private IRepository repository;
        
        private Scene editingScene;

        private PositionableList<SceneManuscriptVersion> sceneManuscriptVersions = new PositionableList<SceneManuscriptVersion>();
        private PositionableList<SceneChecklistVersion> sceneChecklistVersions = new PositionableList<SceneChecklistVersion>();
        private PositionableList<SceneOutlineVersion> sceneOutlineVersions = new PositionableList<SceneOutlineVersion>();



        public List<SceneManuscriptVersion> OrderedManuscriptVersions { get { return sceneManuscriptVersions.ItemsList; } }
        public List<SceneChecklistVersion> OrderedChecklistVersions { get { return sceneChecklistVersions.ItemsList; } }
        public List<SceneOutlineVersion> OrderedOutlineVersions { get { return sceneOutlineVersions.ItemsList; } }


        public SceneManuscriptVersion CurrentManuscript { get { return sceneManuscriptVersions.LastItem; } }
        public SceneChecklistVersion CurrentChecklist { get { return sceneChecklistVersions.LastItem; } }
        public SceneOutlineVersion CurrentOutline { get { return sceneOutlineVersions.LastItem; } }


        public string CurrentManuscriptFile { get { return Path.Combine(repository.Scenes.SceneFolder, this.editingScene.Code, this.CurrentManuscript.File); } }
        public string CurrentOutlineFile { get { return Path.Combine(repository.Scenes.SceneFolder, this.editingScene.Code, this.CurrentOutline.File); } }
        public string CurrentChecklistFile { get { return Path.Combine(repository.Scenes.SceneFolder, this.editingScene.Code, this.CurrentChecklist.File); } }

        public string GetVersionFileFor(SceneManuscriptVersion manuscriptVersion)
        {
            return Path.Combine(repository.Scenes.SceneFolder, manuscriptVersion.Code, this.CurrentManuscript.File);
        }

        public string GetVersionFileFor(SceneOutlineVersion outlineVersion)
        {
            return Path.Combine(repository.Scenes.SceneFolder, outlineVersion.Code, this.CurrentOutline.File);
        }

        public string GetVersionFileFor(SceneChecklistVersion checklistVersion)
        {
            return Path.Combine(repository.Scenes.SceneFolder, checklistVersion.Code, this.CurrentChecklist.File);
        }

        public SceneManuscriptVersion GetManuscriptVersion(string versionCode)
        {
            return sceneManuscriptVersions.ItemsList.Where(r => r.Code == versionCode).SingleOrDefault();
        }

        public SceneOutlineVersion GetOutlineVersion(string versionCode)
        {
            return sceneOutlineVersions.ItemsList.Where(r => r.Code == versionCode).SingleOrDefault();
        }

        public SceneChecklistVersion GetChecklistVersion(string versionCode)
        {
            return sceneChecklistVersions.ItemsList.Where(r => r.Code == versionCode).SingleOrDefault();
        }

        public void CopyVersionAsCurrent(SceneManuscriptVersion sceneManuscriptVersion)
        {
            SceneManuscriptVersion newSceneManuscriptVersion = new SceneManuscriptVersion();
            // any common properties must be set here.
            sceneManuscriptVersions.Insert(newSceneManuscriptVersion);
        }

        public void CopyVersionAsCurrent(SceneOutlineVersion sceneOutlineVersion)
        {
            SceneOutlineVersion newSceneOutlineVersion = new SceneOutlineVersion();
            // any common properties must be set here.
            sceneOutlineVersions.Insert(newSceneOutlineVersion);
        }

        public void CopyVersionAsCurrent(SceneChecklistVersion sceneChecklistVersion)
        {
            SceneChecklistVersion newSceneChecklistVersion = new SceneChecklistVersion();
            // any common properties must be set here.
            sceneChecklistVersions.Insert(newSceneChecklistVersion);
        }

        /// <summary>
        /// Constructor for SceneEditor
        /// </summary>
        /// <param name="scene">The scene to be edited.</param>
        /// <param name="repository">The repository from which to pull information.</param>
        public SceneEditor(Scene scene, IRepository repository)
        {
            this.editingScene = scene;
            this.repository = repository;
            this.sceneManuscriptVersions.InitializeList(repository.Scenes.GetManuscriptHistory(scene));
            this.sceneChecklistVersions.InitializeList(repository.Scenes.GetChecklistHistory(scene));
            this.sceneOutlineVersions.InitializeList(repository.Scenes.GetOutlineHistory(scene));
        }
    }
}
