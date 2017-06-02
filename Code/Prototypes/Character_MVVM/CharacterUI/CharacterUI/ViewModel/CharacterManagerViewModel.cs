using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CharacterDomain.Model;
using CharacterDomain.Repository;

namespace CharacterUI.ViewModel
{
    public class CharacterManagerViewModel : ViewModelBase
    {
        // repository models.
        private ICharacterRepository characterRepository;

        // backing variables.
        ObservableCollection<Character> characterList;

        // events
        public event EventHandler ShowCharacterDetailsForm;

        // constructors
        public CharacterManagerViewModel() : this(new XmlCharacterRepository()) { }
        public CharacterManagerViewModel(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
            this.AddCommand = new DelegateCommand<object>(AddCommand_Execute, AddCommand_CanExecute);
            this.EditCommand = new DelegateCommand<object>(EditCommand_Execute, EditCommand_CanExecute);
            this.DeleteCommand = new DelegateCommand<object>(DeleteCommand_Execute, DeleteCommand_CanExecute);
        }

        public int CharacterCount
        {
            get { return this.CharacterList.Count(); }
        }

        public ObservableCollection<Character> CharacterList
        {
            get
            {
                if (this.characterList == null)
                    this.characterList = new ObservableCollection<Character>(this.characterRepository.GetAllCharacters());
                return this.characterList;
            }
        }


        public DelegateCommand<object> AddCommand { get; private set; }
        public DelegateCommand<object> DeleteCommand { get; private set; }
        public DelegateCommand<object> EditCommand { get; private set; }


        private void EditCommand_Execute(object arg)
        {
            if (this.ShowCharacterDetailsForm != null)
                this.ShowCharacterDetailsForm(this, EventArgs.Empty);
        }

        private bool EditCommand_CanExecute(object arg)
        {
            return true;
        }

        private void DeleteCommand_Execute(object arg)
        {
            base.DisplayMessage(this, "Deleting...");
        }

        private bool DeleteCommand_CanExecute(object arg)
        {
            return true;
        }

        private void AddCommand_Execute(object arg)
        {
            base.DisplayMessage(this, "Deleting...");
        }

        private bool AddCommand_CanExecute(object arg)
        {
            return true;
        }
    }
}
