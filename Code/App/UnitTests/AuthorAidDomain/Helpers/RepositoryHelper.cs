using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using Domain.Entities;
using System.IO;
using Moq;

namespace UnitTests.Helpers
{
    public class RepositoryHelper
    {
        private const string rootFolder = @"C:\Users\robertb\Documents\Work\__Testing";

        //public void MockTest()
        //{
        //    Mock<IRepository> mock = new Mock<IRepository>();
        //    mock.Setup(repo => repo.
        //}

        public static IRepository GetRepository()
        {
            

            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);

            //Domain.Repositories.Repository repository = new Domain.Repositories.Repository(rootFolder);
            IRepository repository = new Repository();


            repository.Create(rootFolder);
            List<Scene> initialSceneList = InitialSceneList();
            repository.Scenes.UpdateScenes(initialSceneList);

            repository.Scenes.UpdateChecklistVersions(InitialSceneChecklistVersions(initialSceneList));
            repository.Scenes.UpdateManuscriptVersions(InitialSceneManuscriptVersions(initialSceneList));
            repository.Scenes.UpdateOutlineVersions(InitialSceneOutlineVersions(initialSceneList));


            //repository.UpdateStorylines(InitialStorylineList());
            //repository.UpdateCharacters(InitialCharacterList());

            repository.AcceptChanges(); // as if we've loaded this data from the database, nothing has been added as new.

            return repository;
        }

        public static void DeleteRepository()
        {
            if (Directory.Exists(rootFolder))
                Directory.Delete(rootFolder, true);
        }


        private static List<Character> InitialCharacterList()
        {
            List<Character> characterList = new List<Character>
            {
                new Character { FullName = "Harry Flynn", Aliases = string.Empty, BirthDate = DateTime.Now.AddYears(-34).AddDays(-34), DeathDate = DateTime.MaxValue, Sex = "MALE" },
                new Character { FullName = "Sally Flynn", Aliases = string.Empty, BirthDate = DateTime.Now.AddYears(-24).AddDays(67), DeathDate = DateTime.MaxValue, Sex = "FEMALE" },
            };
            return characterList;
        }

        private static List<Storyline> InitialStorylineList()
        {
            List<Storyline> storyLineList = new List<Storyline>
            {
                new Storyline { Title = "Storyline 1" },
                new Storyline { Title = "Storyline 1" }
            };
            return storyLineList;
        }

        private static List<SceneOutlineVersion> InitialSceneOutlineVersions(List<Scene> sceneList)
        {
            List<SceneOutlineVersion> sceneOutlineVersions = new List<SceneOutlineVersion>();
            foreach (Scene scene in sceneList)
                sceneOutlineVersions.AddRange(CreateSceneOutlineVersionList(scene));

            return sceneOutlineVersions;
        }

        private static List<SceneManuscriptVersion> InitialSceneManuscriptVersions(List<Scene> sceneList)
        {
            List<SceneManuscriptVersion> sceneManuscriptVersions = new List<SceneManuscriptVersion>();
            foreach (Scene scene in sceneList)
                sceneManuscriptVersions.AddRange(CreateSceneManuscriptVersionList(scene));

            return sceneManuscriptVersions;
        }

        private static List<SceneChecklistVersion> InitialSceneChecklistVersions(List<Scene> sceneList)
        {
            List<SceneChecklistVersion> sceneChecklistVersions = new List<SceneChecklistVersion>();
            foreach (Scene scene in sceneList)
                sceneChecklistVersions.AddRange(CreateSceneChecklistVersionList(scene));

            return sceneChecklistVersions;
        }

        private static List<SceneOutlineVersion> CreateSceneOutlineVersionList(Scene scene)
        {
            List<SceneOutlineVersion> sceneOutlineVersions = new List<SceneOutlineVersion>
            {
                new SceneOutlineVersion { SceneCode = scene.Code, Ordinal = 1},
                new SceneOutlineVersion { SceneCode = scene.Code, Ordinal = 2},
                new SceneOutlineVersion { SceneCode = scene.Code, Ordinal = 3,},
                new SceneOutlineVersion { SceneCode = scene.Code, Ordinal = 4},
            };
            return sceneOutlineVersions;
        }

        private static List<SceneManuscriptVersion> CreateSceneManuscriptVersionList(Scene scene)
        {
            List<SceneManuscriptVersion> sceneManuscriptVersions = new List<SceneManuscriptVersion>
            {
                new SceneManuscriptVersion { SceneCode = scene.Code, Ordinal = 1},
                new SceneManuscriptVersion { SceneCode = scene.Code, Ordinal = 2},
                new SceneManuscriptVersion { SceneCode = scene.Code, Ordinal = 3,},
                new SceneManuscriptVersion { SceneCode = scene.Code, Ordinal = 4},
            };
            return sceneManuscriptVersions;
        }

        private static List<SceneChecklistVersion> CreateSceneChecklistVersionList(Scene scene)
        {
            List<SceneChecklistVersion> sceneChecklistVersions = new List<SceneChecklistVersion>
            {
                new SceneChecklistVersion { SceneCode = scene.Code, Ordinal = 1},
                new SceneChecklistVersion { SceneCode = scene.Code, Ordinal = 2},
                new SceneChecklistVersion { SceneCode = scene.Code, Ordinal = 3,},
                new SceneChecklistVersion { SceneCode = scene.Code, Ordinal = 4},
            };
            return sceneChecklistVersions;
        }

        private static List<Scene> InitialSceneList()
        {
            List<Scene> scenes = new List<Scene>
            {
                new Scene { Ordinal = 2, Title = "Scene 2 - The middle of the adventure", Summary = "Summary 2", PercentComplete = 25, CurrentRevisionId = 1 },
                new Scene { Ordinal = 1, Title = "Scene 1 - The start of the adventure", Summary = "Summary 1", PercentComplete = 72, CurrentRevisionId = 1 },
                new Scene { Ordinal = 3, Title = "Scene 3 - The end of the adventure", Summary = "Summary 3", PercentComplete = 5,  CurrentRevisionId = 1 }
            };
            return scenes;
        }
    }
}
