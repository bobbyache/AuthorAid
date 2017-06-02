using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Positioning;
using CygX1.PersistentObjects;


namespace Domain.Entities
{
    public class Scene : PersistableEntity, IPositionedItem
    {
        public class SceneRevision
        {
            internal SceneRevision(int id, string description)
            {
                Id = id;
                Description = description;
            }
            public int Id { get; private set; }
            public string Description { get; private set; }

            public override string ToString()
            {
                return string.Format("{0} - {1}", Id, Description);
            }
        }

        public static SceneRevision[] GetSceneRevisionPhases() { return GetRevisionList().ToArray(); }

        private static List<SceneRevision> sceneRevisionList = null;
        private static List<SceneRevision> GetRevisionList()
        {
            if (sceneRevisionList == null)
            {
                sceneRevisionList = new List<SceneRevision>()
                {
                    new SceneRevision(1, "Outline"),
                    new SceneRevision(2, "Draft"),
                    new SceneRevision(3, "1st Edit"),
                    new SceneRevision(4, "2nd Edit"),
                    new SceneRevision(5, "Final Edit")
                };
            }
            return sceneRevisionList;
        }

        public static SceneRevision GetSceneRevision(int id)
        {
            return GetSceneRevisionPhases().Where(r => r.Id == id).SingleOrDefault();
        }

        private SceneRevision currentRevision;

        private const string CurrentRevisionIdName = "CurrentRevisionId";
        public int CurrentRevisionId
        {
            get
            {
                if (currentRevision == null)
                    currentRevision = GetSceneRevision(1);
                return currentRevision.Id;
            }
            set
            {
                if (currentRevision == null)
                {
                    currentRevision = GetSceneRevision(value);
                    RaisePropertyChanged(CurrentRevisionIdName);
                }
                else if (currentRevision.Id != value)
                {
                    currentRevision = GetSceneRevision(value);
                    RaisePropertyChanged(CurrentRevisionIdName);
                }
            }
        }

        public string CurrentRevisionDescription { get { return this.currentRevision.Description; } }

        private const string CurrentRevisionName = "CurrentRevision";
        public SceneRevision CurrentRevision
        {
            get
            {
                if (currentRevision == null)
                    currentRevision = GetSceneRevision(1);
                return currentRevision;
            }
            set
            {
                if (currentRevision != value)
                {
                    currentRevision = value;
                    RaisePropertyChanged(CurrentRevisionName);
                }
            }
        }
        
        public const string OrdinalPropertyName = "Ordinal";
        private int ordinal = -1;
        public int Ordinal
        {
            get { return ordinal; }
            set
            {
                if (ordinal != value)
                {
                    ordinal = value;
                    RaisePropertyChanged(OrdinalPropertyName);
                }
            }
        }

        public const string TitlePropertyName = "Title";
        private string title = string.Empty;
        public string Title
        {
            get { return title; }

            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged(TitlePropertyName);
                }
            }
        }

        public const string PercentCompletePropertyName = "PercentComplete";
        private int percentComplete = 0;
        public int PercentComplete
        {
            get { return percentComplete; }

            set
            {
                if (percentComplete != value)
                {
                    percentComplete = value;
                    RaisePropertyChanged(PercentCompletePropertyName);
                }
            }
        }

        public const string SummaryPropertyName = "Summary";
        private string summary = string.Empty;
        public string Summary
        {
            get { return summary; }
            set
            {
                if (summary != value)
                {
                    summary = value;
                    RaisePropertyChanged(SummaryPropertyName);
                }
            }
        }
    }
}
