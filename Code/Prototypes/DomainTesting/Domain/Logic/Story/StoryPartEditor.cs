//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CygX1.AuthorAid.Domain.Repositories;
//using CygX1.AuthorAid.Domain.Common.Positioning;
//using System.IO;

//namespace CygX1.AuthorAid.Domain.Logic.Story
//{
//    public class StoryPartEditor
//    {
//        StoryPart storyPart;
//        private string storyPartFolder = string.Empty;
//        IStoryRepository storylineRepository;
//        private PositionableList<StoryPartVersion> versionList;

//        public StoryPartEditor(IStoryRepository storylineRepository, StoryPart storyPart, string storyPartFolder)
//        {
//            this.storyPart = storyPart;
//            this.storylineRepository = storylineRepository;
//            this.storyPartFolder = storyPartFolder;
//            this.versionList = new PositionableList<StoryPartVersion>();
//            this.versionList.InitializeList(storylineRepository.GetStoryPartVersions(this.storyPart.UniqueCode));
//        }

//        public StoryPart CurrentStoryPart { get { return this.storyPart; } }

//        public List<StoryPartVersion> Versions { get { return this.versionList.ItemsList; } }

//        public StoryPartVersion CurrentVersion 
//        {
//            get { return versionList.LastItem; }
//        }

//        public void CreateNewCurrentVersion(StoryPartVersion storyPartVersion)
//        {
//            StoryPartVersion copyVersion = new StoryPartVersion();
//            copyVersion.StoryPartCode = storyPartVersion.StoryPartCode;
//            copyVersion.Content = storyPartVersion.Content;

//            if (copyVersion != null)
//            {
//                versionList.Insert(copyVersion);
//                storylineRepository.UpdateStoryPartVersion(copyVersion);
//            }
//        }
//    }
//}
