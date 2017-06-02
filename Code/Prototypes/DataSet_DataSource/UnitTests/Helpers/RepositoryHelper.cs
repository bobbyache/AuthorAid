using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using Domain.Entities;
using System.IO;

namespace UnitTests.Helpers
{
    public class RepositoryHelper
    {
        private const string rootFolder = @"D:\AppTesting";

        public static Repository GetRepository()
        {
            

            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);

            Domain.Repositories.Repository repository = new Domain.Repositories.Repository(rootFolder);

            repository.Create();
            List<Scene> initialSceneList = InitialSceneList();
            repository.Scenes.UpdateScenes(initialSceneList);
            repository.Scenes.UpdateSceneVersions(InitialSceneVersionList(initialSceneList));
            repository.UpdateStorylines(InitialStorylineList());
            repository.UpdateCharacters(InitialCharacterList());

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

        private static List<SceneVersion> InitialSceneVersionList(List<Scene> sceneList)
        {
            List<SceneVersion> sceneVersions = new List<SceneVersion>();
            foreach (Scene scene in sceneList)
                sceneVersions.AddRange(CreateSceneVersionList(scene));

            return sceneVersions;
        }

        private static List<SceneVersion> CreateSceneVersionList(Scene scene)
        {
            List<SceneVersion> sceneVersions = new List<SceneVersion>
            {
                new SceneVersion { SceneCode = scene.Code, Ordinal = 1},
                new SceneVersion { SceneCode = scene.Code, Ordinal = 2},
                new SceneVersion { SceneCode = scene.Code, Ordinal = 3,},
                new SceneVersion { SceneCode = scene.Code, Ordinal = 4},
            };
            return sceneVersions;
        }

        private static List<Scene> InitialSceneList()
        {
            List<Scene> scenes = new List<Scene>
            {
                new Scene { Ordinal = 2, Title = "Scene 2 - The middle of the adventure", Summary = "Summary 2", PercentComplete = 25},
                new Scene { Ordinal = 1, Title = "Scene 1 - The start of the adventure", Summary = "Summary 1", PercentComplete = 72},
                new Scene { Ordinal = 3, Title = "Scene 3 - The end of the adventure", Summary = "Summary 3", PercentComplete = 5}
            };
            return scenes;
        }
    }
}
