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
        //private ISceneManuscript sceneManuscript;
        
        private Scene editingScene;
        private PositionableList<SceneVersion> sceneVersions = new PositionableList<SceneVersion>();

        public List<SceneVersion> OrderedVersions { get { return sceneVersions.ItemsList; } }
        public SceneVersion CurrentVersion { get { return sceneVersions.LastItem; } }

        public string CurrentVersionFile
        {
            // this is the only part of the manuscript that this object will know about.
            // the manuscript itself will be handled, saved, by the front-end text editor !!!
            get
            {
                 return Path.Combine(repository.Scenes.SceneFolder, this.editingScene.Code, this.CurrentVersion.SceneFile); 
            }
        }

        public string GetVersionFileFor(SceneVersion sceneVersion)
        {
            return Path.Combine(repository.Scenes.SceneFolder, sceneVersion.Code, this.CurrentVersion.SceneFile); 
        }

        public SceneEditor(Scene scene, IRepository repository)
        {
            this.editingScene = scene;
            this.repository = repository;
            this.sceneVersions.InitializeList(repository.Scenes.GetVersionHistory(scene));
        }

        public SceneVersion GetVersion(string versionCode)
        {
            return sceneVersions.ItemsList.Where(r => r.Code == versionCode).SingleOrDefault();
        }

        public void CopyVersionAsCurrent(SceneVersion sceneVersion)
        {
            SceneVersion newSceneVersion = new SceneVersion();
            // any common properties must be set here.
            sceneVersions.Insert(newSceneVersion);
        }
    }
}
