using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using CharacterDomain.Repository;
using CharacterTests.TestDomain;
using CharacterDomain.Model;
using Moq;
using CharacterUI.ViewModel;
using System.Collections.ObjectModel;


namespace CharacterTests
{
    [TestClass]
    public class DomainObjectTests
    {
        private IKernel kernel = new StandardKernel();

        [TestInitialize]
        public void Setup()
        {
            kernel.Bind<ICharacterRepository>().To<TestCharacterRepository>();
            
            //mock.Setup(m => m.GetAllCharacters()).Returns(products);
        }

        [TestMethod]
        public void GetAllCharacters_FromView()
        {

            List<Character> characterFile = new List<Character> 
            { 
                new Character() { FamiliarName = "Johnny", Aliases = "", FullName = "John Black", Description = "Johnny is the main protagonist." },
                new Character() { FamiliarName = "Sally", Aliases = "", FullName = "Sally Fox", Description = "Sally is the mistress in distress." },
                new Character() { FamiliarName = "Billy Boy", Aliases = "", FullName = "Bill Benson", Description = "The village bully that must be bested." },
                new Character() { FamiliarName = "Mr. Claasens", Aliases = "", FullName = "Carl Claasens", Description = "Teacher of the drunken martial arts." },
            };

            Mock<ICharacterRepository> mock = new Mock<ICharacterRepository>();
            mock.Setup(m => m.GetAllCharacters()).Returns(characterFile);

            CharacterManagerViewModel viewModel = new CharacterManagerViewModel(mock.Object);


            Assert.IsTrue(viewModel.CharacterList.Count > 0);
        }



        [TestMethod]
        public void SaveCharacter_NewMocked()
        {
            List<Character> characterFile = new List<Character> 
            { 
                new Character() { FamiliarName = "Johnny", Description = "Johnny is the main protagonist." },
                new Character() { FamiliarName = "Sally", Description = "Sally is the mistress in distress." },
                new Character() { FamiliarName = "Billy Boy", Description = "The village bully that must be bested." },
                new Character() { FamiliarName = "Mr. Claasens", Description = "Teacher of the drunken martial arts." },
            };

            Mock<ICharacterRepository> mock = new Mock<ICharacterRepository>();
            mock.Setup(m => m.GetAllCharacters()).Returns(characterFile);

            List<Character> characterList = mock.Object.GetAllCharacters();
            //IKernel kern = new StandardKernel();
        }

        [TestMethod]
        public void SaveCharacter_New()
        {
            //--------------------------------------------------------------------------------
            // Arrange
            //--------------------------------------------------------------------------------
            ICharacterRepository repository = kernel.Get<ICharacterRepository>();

            //--------------------------------------------------------------------------------
            // Act
            //--------------------------------------------------------------------------------
            List<Character> characterList = repository.GetAllCharacters();
            int initialCount = characterList.Count;

            Character character = new Character();
            character.FamiliarName = "Adrian";
            character.Description = "An old friend of Johnny";

            repository.SaveCharacter(character);

            //--------------------------------------------------------------------------------
            // Assert
            //--------------------------------------------------------------------------------
            Assert.IsTrue(character.DateCreated != DateTime.MinValue);
            Assert.IsTrue(character.DateModified != DateTime.MinValue);
            Assert.IsFalse(string.IsNullOrEmpty(character.Id));

            Assert.IsTrue(repository.GetAllCharacters().Count == initialCount + 1);

        }

        [TestMethod]
        public void GetAllCharacters()
        {
            //--------------------------------------------------------------------------------
            // Arrange
            //--------------------------------------------------------------------------------
            ICharacterRepository repository = kernel.Get<ICharacterRepository>();

            //--------------------------------------------------------------------------------
            // Act
            //--------------------------------------------------------------------------------
            List<Character> characterList = repository.GetAllCharacters();

            //--------------------------------------------------------------------------------
            // Assert
            //--------------------------------------------------------------------------------
            // that something is passed back.
            Assert.IsTrue(characterList.Count > 0);



            //Moq.Mock<ICloneable> mock = new Moq.Mock<ICloneable>();
            //Ninject.
            //IKernel stdKernel = new StandardKernel
        }
    }
}
