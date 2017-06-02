using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Domain.Entities;
using CygX1.PersistentObjects;


namespace CygX1.AuthorAid.Windows.ViewModel
{
    public class SceneViewModel : ViewModelBase
    {
        private Scene scene;

        public SceneViewModel()
        {
            //scene.Code = "";
            scene.CurrentState = PersistableEntityStateEnum.Added;
            //scene.DateCreated = DateTime.Now;
            //scene.DateModified = DateTime.Now;
            scene.Ordinal = 1;
            scene.PercentComplete = 80;
            scene.Summary = "Summary";
            scene.Title = "Title";
        }


        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string title = string.Empty;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (title == value)
                {
                    return;
                }

                //RaisePropertyChanging(TitlePropertyName);
                title = value;
                RaisePropertyChanged(TitlePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Summary" /> property's name.
        /// </summary>
        public const string SummaryPropertyName = "Summary";

        private string summary = string.Empty;

        /// <summary>
        /// Sets and gets the Summary property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Summary
        {
            get
            {
                return summary;
            }

            set
            {
                if (summary == value)
                {
                    return;
                }

                //RaisePropertyChanging(SummaryPropertyName);
                summary = value;
                RaisePropertyChanged(SummaryPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="PercentComplete" /> property's name.
        /// </summary>
        public const string PercentCompletePropertyName = "PercentComplete";

        private int percentComplete = 0;

        /// <summary>
        /// Sets and gets the PercentComplete property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PercentComplete
        {
            get
            {
                return percentComplete;
            }

            set
            {
                if (percentComplete == value)
                {
                    return;
                }

                //RaisePropertyChanging(PercentCompletePropertyName);
                percentComplete = value;
                RaisePropertyChanged(PercentCompletePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Ordinal" /> property's name.
        /// </summary>
        public const string OrdinalPropertyName = "Ordinal";

        private int ordinal = 0;

        /// <summary>
        /// Sets and gets the Ordinal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Ordinal
        {
            get
            {
                return ordinal;
            }

            set
            {
                if (ordinal == value)
                {
                    return;
                }

                //RaisePropertyChanging(OrdinalPropertyName);
                ordinal = value;
                RaisePropertyChanged(OrdinalPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CurrentState" /> property's name.
        /// </summary>
        public const string CurrentStatePropertyName = "CurrentState";

        private PersistableEntityStateEnum currentState = PersistableEntityStateEnum.Unchanged;

        /// <summary>
        /// Sets and gets the CurrentState property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PersistableEntityStateEnum CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                if (currentState == value)
                {
                    return;
                }

                currentState = value;
                RaisePropertyChanged(CurrentStatePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Code" /> property's name.
        /// </summary>
        public const string CodePropertyName = "Code";

        private string code = string.Empty;

        /// <summary>
        /// Sets and gets the Code property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                if (code == value)
                    return;
                code = value;
                RaisePropertyChanged(CodePropertyName);
            }
        }
    }
}
