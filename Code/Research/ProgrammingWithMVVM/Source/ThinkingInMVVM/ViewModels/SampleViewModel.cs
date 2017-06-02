using System;
using System.Windows.Media;

namespace MVVMDemo.ViewModel
{
    public class SampleViewModel : ViewModelBase
    {
        public SampleViewModel()
        {
            InitializeViewModel();
        }

        protected override void InitializeViewModel()
        {
            ChangeColorCommand = new DelegateCommand<Brush>(
                ChangeColorCommand_Execute, ChangeColorCommand_CanExecute);
        }

        public override string ViewName
        {
            get { return "MVVM Thinking - After"; }
        }

        public string LabelCaption { get { return "This is my content"; } }
        public string Color1Caption { get { return "Color 1"; } }
        public string Color2Caption { get { return "Color 2"; } }

        Brush _ContentColor = Brushes.Green;

        public DelegateCommand<Brush> ChangeColorCommand { get; protected set; }

        public Brush ContentColor
        {
            get { return _ContentColor; }
            set
            {
                if (_ContentColor == value)
                    return;

            	_ContentColor = value;
                OnPropertyChanged("ContentColor", false);
            }
        }

        void ChangeColorCommand_Execute(Brush arg)
        {
            ContentColor = arg;
        }

        bool ChangeColorCommand_CanExecute(Brush arg)
        {
            bool ret = false;

            if (arg != _ContentColor)
                ret = true;

            return ret;
        }
    }
}
